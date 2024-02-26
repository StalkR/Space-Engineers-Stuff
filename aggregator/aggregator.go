package main

import (
	"fmt"
	"log"
	"strconv"
	"strings"
	"sync"
	"time"
)

type Aggregator struct {
	m       sync.Mutex // protects below
	servers []string
	infos   map[string]*ServerInfo
}

func NewAggregator(servers string) (*Aggregator, error) {
	serverList, err := validateServers(servers)
	if err != nil {
		return nil, err
	}
	return &Aggregator{
		servers: serverList,
		infos:   map[string]*ServerInfo{},
	}, nil
}

func (s *Aggregator) Aggregate(sleep time.Duration) {
	for ; ; time.Sleep(sleep) {
		s.m.Lock()
		servers := s.servers
		s.m.Unlock()
		for _, server := range servers {
			info, err := queryInfo(server)
			if err != nil {
				log.Printf("query %v error: %v", server, err)
				continue
			}
			log.Printf("querying %v: %v players", server, info.Players)
			s.m.Lock()
			s.infos[server] = info
			s.m.Unlock()
		}
	}
}

func (s *Aggregator) Info() *ServerInfo {
	s.m.Lock()
	defer s.m.Unlock()
	aggregate, ok := s.infos[s.servers[0]]
	if !ok {
		return nil
	}
	totalPlayers := 0
	for _, info := range s.infos {
		totalPlayers += int(info.Players)
	}
	if totalPlayers > 255 {
		totalPlayers = 255
	}
	aggregate.Players = uint8(totalPlayers)
	if aggregate.MaxPlayers < aggregate.Players {
		aggregate.MaxPlayers = aggregate.Players
	}
	return aggregate
}

func (s *Aggregator) Players() ServerPlayers {
	// packet would be too big at some point
	// some servers don't even reply the player names
	// responding nothing doesn't impact fetchers
	return nil
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
