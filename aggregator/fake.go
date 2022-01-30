package main

import "strings"

type Fake struct {
  info    *ServerInfo
  players ServerPlayers
}

func NewFake() *Fake {
  var serverType uint8
  if len(*flagType) > 0 {
    serverType = uint8((*flagType)[0])
  }
  var environment uint8
  if len(*flagEnvironment) > 0 {
    environment = uint8((*flagEnvironment)[0])
  }

  var players ServerPlayers
  for _, e := range strings.Split(*flagPlayerList, ",") {
    if e == "" {
      continue
    }
    players = append(players, &ServerPlayer{
      Index:    0,
      Name:     e,
      Score:    0,
      Duration: 0,
    })
  }

  return &Fake{
    info: &ServerInfo{
      Name:        *flagName,
      MapName:     *flagMap,
      Folder:      *flagFolder,
      Game:        *flagGame,
      AppID:       uint16(*flagAppID),
      Players:     uint8(*flagPlayers),
      MaxPlayers:  uint8(*flagMaxPlayers),
      Bots:        uint8(0),
      ServerType:  serverType,
      Environment: environment,
      Visibility:  uint8(*flagVisibility),
      VAC:         uint8(*flagVAC),
      Version:     *flagVersion,
      EDF:         0,
    },
    players: players,
  }
}

func (s *Fake) Info() *ServerInfo      { return s.info }
func (s *Fake) Players() ServerPlayers { return s.players }
