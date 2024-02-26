/*
Binary aggregator aggregates and serves Source server information.

Given a list of servers, it regularly queries them for information.
It serves the same information as the first server, but for the player count
it shows the sum of players across all servers, adjusting max players if
necessary. The player fields being 8-bit, both are capped at 255.
The aggregator responds no players to the player info request.

It can also take the list of servers from a Nexus config.

Protocol: https://developer.valvesoftware.com/wiki/Server_queries

To aggregate multiple servers and serve:
  go run . -listen :27016 -servers main:port,second:port

To aggregate servers from a Nexus config:
  go run . -listen :27016 -nexus NexusControlConfig.cfg

To fake a server and serve:
  go run . -listen :27016 -name Name -map Map -folder Folder -game Game \
    -appid 0 -players 1 -maxplayers 2 -type d -environment w -visibility 0 \
    -vac 1 -version version -playerlist a,b,c

A tool to query information and players from a server:
  go run . -query host:port [-log]
*/

package main

import (
  "flag"
  "log"
  "time"
)

var (
  // query: -query host:port
  flagQuery = flag.String("query", "", "Query server host:port for info and players, print and exit.")
  flagLog   = flag.Bool("log", false, "Query shows the server name and players on a single log line.")

  // aggregator & fake: -listen [addr:]port
  flagListen = flag.String("listen", ":27016", "Port to listen on (UDP).")

  // aggregator: -servers host:port[,host:port,...]
  flagServers = flag.String("servers", "", "Comma-separated list of host:port servers to aggregate.")

  // aggregator: -nexus NexusControlConfig.cfg
  flagNexus = flag.String("nexus", "", "Path to NexusControlConfig.cfg to find the servers to aggregate.")

  // fake: -name name -map -folder -game -appid -players 1 -maxplayers 2 etc.
  flagName        = flag.String("name", "", "Server name.")
  flagMap         = flag.String("map", "", "Server map.")
  flagFolder      = flag.String("folder", "", "Server folder.")
  flagGame        = flag.String("game", "", "Server game.")
  flagAppID       = flag.Int("appid", 0, "Server appID.")
  flagPlayers     = flag.Int("players", 0, "Server players.")
  flagMaxPlayers  = flag.Int("maxplayers", 0, "Server max players.")
  flagType        = flag.String("type", "", "Server type.")
  flagEnvironment = flag.String("environment", "", "Server environment.")
  flagVisibility  = flag.Int("visibility", 0, "Server visibility.")
  flagVAC         = flag.Int("vac", 0, "Server VAC.")
  flagVersion     = flag.String("version", "", "Server version.")
  flagPlayerList  = flag.String("playerlist", "", "Server player list (comma-separated).")
)

func main() {
  flag.Parse()

  if *flagQuery != "" {
    if err := query(*flagQuery); err != nil {
      log.Fatal(err)
    }
    return
  }

  if *flagName != "" {
    if err := NewServer(NewFake()).ListenAndServe(*flagListen); err != nil {
      log.Fatal(err)
    }
    return
  }

  const pollDelay = time.Minute

  if *flagNexus != "" {
    a, err := NewNexusAggregator(*flagNexus)
    if err != nil {
      log.Fatal(err)
    }
    go a.WatchConfig(pollDelay)
    go a.Aggregate(pollDelay)
    if err := NewServer(a).ListenAndServe(*flagListen); err != nil {
      log.Fatal(err)
    }
    return
  }

  a, err := NewAggregator(*flagServers)
  if err != nil {
    log.Fatal(err)
  }
  go a.Aggregate(pollDelay)
  if err := NewServer(a).ListenAndServe(*flagListen); err != nil {
    log.Fatal(err)
  }
}
