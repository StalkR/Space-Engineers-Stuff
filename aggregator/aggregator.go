package main

import (
	"log"
	"sync"
	"time"
)

type Aggregator struct {
	first string
	m     sync.Mutex
	infos map[string]*ServerInfo
}

func NewAggregator(servers []string) *Aggregator {
	infos := map[string]*ServerInfo{}
	for _, s := range servers {
		infos[s] = nil
	}
	return &Aggregator{first: servers[0], infos: infos}
}

func (s *Aggregator) Aggregate() {
	for ; ; time.Sleep(time.Minute) {
		for server := range s.infos {
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
	aggregate := *s.infos[s.first]
	totalPlayers := 0
	for _, info := range s.infos {
		totalPlayers += int(info.Players)
	}
	s.m.Unlock()
	if totalPlayers > 255 {
		totalPlayers = 255
	}
	aggregate.Players = uint8(totalPlayers)
	if aggregate.MaxPlayers < aggregate.Players {
		aggregate.MaxPlayers = aggregate.Players
	}
	return &aggregate
}

func (s *Aggregator) Players() ServerPlayers {
	// packet would be too big at some point
	// some servers don't even reply the player names
	// and looks like responding nothing doesn't impact some fetchers
	return nil
}
