package main

import (
  "encoding/xml"
  "fmt"
  "os"
)

func handleAdmins() error {
  f, err := os.Open(*sandboxFlag)
  if err != nil {
    return err
  }
  defer f.Close()
  var v MyObjectBuilder_Checkpoint
  if err := xml.NewDecoder(f).Decode(&v); err != nil {
    return err
  }

  playerNames := map[int64]string{}
  for _, p := range v.Identities {
    playerNames[p.IdentityId] = p.DisplayName
  }

  fmt.Printf("Players: %v\n", len(playerNames))

  admins := 0
  for _, value := range v.AllPlayersData {
    v := value.Value
    switch v.PromoteLevel {
    case "None", "Scripter":
      continue
    }
    fmt.Printf("%v is %v (settings: %v, creative: %v) SteamID %v\n",
      playerNames[v.IdentityId],
      v.PromoteLevel,
      v.RemoteAdminSettings,
      v.CreativeToolsEnabled,
      resolveSteamID(v.IdentityId, playerNames[v.IdentityId]))
    admins++
  }
  fmt.Printf("Admins: %v\n", admins)
  return nil
}
