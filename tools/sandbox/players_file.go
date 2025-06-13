package main

import (
  "encoding/json"
  "os"
)

var (
  identityIDToSteamID = map[int64]int64{}
  playerNameToSteamID = map[string]int64{}
)

func parsePlayersFile(filename string) error {
  f, err := os.Open(filename)
  if err != nil {
    return err
  }
  defer f.Close()
  var v []playerJSON
  if err := json.NewDecoder(f).Decode(&v); err != nil {
    return err
  }

  for _, p := range v {
    identityIDToSteamID[p.IdentityID] = p.SteamID
    playerNameToSteamID[p.Player] = p.SteamID
  }
  return nil
}

type playerJSON struct {
  Player     string `json:"Player"`
  SteamID    int64  `json:"SteamID"`
  IdentityID int64  `json:"IdentityID"`
}

func resolveSteamID(identityID int64, name string) int64 {
  if steamID, ok := identityIDToSteamID[identityID]; ok {
    return steamID
  }
  if steamID, ok := playerNameToSteamID[name]; ok {
    return steamID
  }
  return 0
}
