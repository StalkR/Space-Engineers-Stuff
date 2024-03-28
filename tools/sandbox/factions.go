package main

import (
	"encoding/xml"
	"fmt"
	"os"
	"strings"
)

func handleFactions() error {
	f, err := os.Open(*sandboxFlag)
	if err != nil {
		return err
	}
	defer f.Close()
	var v MyObjectBuilder_Checkpoint
	if err := xml.NewDecoder(f).Decode(&v); err != nil {
		return err
	}

	factionTags := map[int64]string{}
	factionNames := map[int64]string{}
	factionMembers := map[int64]map[int64]bool{}
	playerFactions := map[int64]int64{}
	for _, f := range v.Factions {
		factionTags[f.FactionId] = f.Tag
		factionNames[f.FactionId] = f.Name
		members := map[int64]bool{}
		for _, m := range f.Members {
			members[m.PlayerId] = true
			playerFactions[m.PlayerId] = f.FactionId
		}
		factionMembers[f.FactionId] = members
	}

	playerNames := map[int64]string{}
	playersWithoutFaction := map[int64]bool{}
	for _, p := range v.Identities {
		playerNames[p.IdentityId] = p.DisplayName
		if _, ok := playerFactions[p.IdentityId]; !ok {
			playersWithoutFaction[p.IdentityId] = true
		}
	}

	fmt.Printf("Factions: %v\n", len(factionTags))
	for fid := range factionNames {
		var members []string
		for pid := range factionMembers[fid] {
			members = append(members, playerNames[pid])
		}
		fmt.Printf(" - [%v] %v, members: %v (%v)\n", factionTags[fid], factionNames[fid], len(members), strings.Join(members, ", "))
	}

	fmt.Printf("Players: %v\n", len(playerNames))
	var factionless []string
	for id := range playersWithoutFaction {
		factionless = append(factionless, playerNames[id])
	}
	fmt.Printf("Players without faction (%v): %v\n", len(factionless), strings.Join(factionless, ", "))
	return nil
}
