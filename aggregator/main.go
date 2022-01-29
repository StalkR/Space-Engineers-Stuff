/*
Binary aggregator aggregates and serves Source server information.

Given a list of servers, it regularly queries them for information.
It serves the same information as the first server, but for the player count
it shows the sum of players across all servers, adjusting max players if
necessary. The player fields being 8-bit, both are capped at 255.
The aggregator responds no players to the player info request.

Protocol: https://developer.valvesoftware.com/wiki/Server_queries

To aggregate multiple servers and serve:
  go run . -listen :27016 -servers main:port,second:port

Additionally, a tool to query information and players from a server:
  go run . -query host:port
*/

package main

import (
  "flag"
  "fmt"
  "log"
  "strconv"
  "strings"
)

var (
  flagListen  = flag.String("listen", ":27016", "Port to listen on (UDP).")
  flagServers = flag.String("servers", "", "Comma-separated list of host:port servers to aggregate.")
  flagQuery   = flag.String("query", "", "Query server host:port for info and players and exits.")
)

func main() {
  flag.Parse()

  if *flagQuery != "" {
    if err := query(*flagQuery); err != nil {
      log.Fatal(err)
    }
    return
  }

  servers, err := validateServers(*flagServers)
  if err != nil {
    log.Fatal(err)
  }
  a := NewAggregator(servers)
  go a.Aggregate()
  if err := NewServer(a).ListenAndServe(*flagListen); err != nil {
    log.Fatal(err)
  }
}

func validateServers(a string) ([]string, error) {
  if a == "" {
    return nil, fmt.Errorf("need at least one server defined in -servers")
  }
  list := strings.Split(a, ",")
  for _, s := range list {
    p := strings.Split(s, ":")
    if len(p) != 2 {
      return nil, fmt.Errorf("invalid server %q", s)
    }
    if port, err := strconv.Atoi(p[1]); err != nil || port < 0 || port > (1<<16)-1 {
      return nil, fmt.Errorf("invalid port in %q", s)
    }
  }
  return list, nil
}
