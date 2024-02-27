package main

import (
  "encoding/xml"
  "fmt"
  "log"
  "os"
  "reflect"
  "time"
)

type NexusAggregator struct {
  Aggregator
  config string
}

func NewNexusAggregator(config string) (*NexusAggregator, error) {
  servers, err := parseNexusConfigFile(config)
  if err != nil {
    return nil, err
  }
  if len(servers) == 0 {
    return nil, fmt.Errorf("invalid nexus config: no servers")
  }
  log.Printf("servers in nexus config (%v): %v", len(servers), servers)
  return &NexusAggregator{
    config: config,
    Aggregator: Aggregator{
      servers: servers,
      infos:   map[string]*ServerInfo{},
    },
  }, nil
}

func (s *NexusAggregator) WatchConfig(sleep time.Duration) {
  for ; ; time.Sleep(sleep) {
    servers, err := parseNexusConfigFile(s.config)
    if err != nil {
      log.Printf("could not read nexus config: %v", err)
      continue
    }
    if len(servers) == 0 {
      log.Print("invalid nexus config: no servers")
      continue
    }
    s.m.Lock()
    oldServers := s.servers
    s.m.Unlock()
    if reflect.DeepEqual(servers, oldServers) {
      continue
    }
    log.Printf("nexus config changed: before %v (%v), after %v (%v)", len(oldServers), oldServers, len(servers), servers)
    s.m.Lock()
    s.servers = servers
    s.m.Unlock()
    s.cleanup()
  }
}

func parseNexusConfigFile(config string) ([]string, error) {
  f, err := os.Open(config)
  if err != nil {
    return nil, err
  }
  defer f.Close()
  var v nexusConfig
  if err := xml.NewDecoder(f).Decode(&v); err != nil {
    return nil, err
  }
  return parseNexusConfig(&v)
}

func parseNexusConfig(cfg *nexusConfig) ([]string, error) {
  var servers []string
  for _, e := range cfg.ConfiguredServers.Server {
    servers = append(servers, fmt.Sprintf("%s:%s", e.IPAddress, e.Port))
  }
  return servers, nil
}

type nexusConfig struct {
  XMLName           xml.Name `xml:"Config"`
  ConfiguredServers struct {
    XMLName xml.Name `xml:"ConfiguredServers"`
    Server  []struct {
      XMLName   xml.Name `xml:"Server"`
      Name      string   `xml:"Name"`
      IPAddress string   `xml:"IPAddress"`
      Port      string   `xml:"Port"`
    } `xml:"Server"`
  } `xml:"ConfiguredServers"`
}

// cleanup cleans up the infos map.
// If the nexus config changes with new IP/ports all the time, we keep adding
// to the infos map but never delete. It's hardly going to be a problem in
// practice, but this fixes it anyway.
func (s *NexusAggregator) cleanup() {
  servers := map[string]bool{}
  for _, server := range s.servers {
    servers[server] = true
  }
  s.m.Lock()
  defer s.m.Unlock()
  for k := range s.infos {
    if !servers[k] {
      delete(s.infos, k)
    }
  }
}
