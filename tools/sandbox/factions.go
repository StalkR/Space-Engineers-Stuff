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

	reputations := map[int64]map[int64]int{}
	for _, r := range v.Relations {
		if v, ok := reputations[r.FactionId1]; ok {
			if _, ok := v[r.FactionId2]; ok {
				fmt.Printf("error: duplicate faction relation for %v (%v) and %v (%v)\n",
					r.FactionId1, factionTags[r.FactionId1], r.FactionId2, factionTags[r.FactionId2])
			}
		} else {
			reputations[r.FactionId1] = map[int64]int{}
		}
		reputations[r.FactionId1][r.FactionId2] = r.Reputation

		if v, ok := reputations[r.FactionId2]; ok {
			if _, ok := v[r.FactionId1]; ok {
				fmt.Printf("error: duplicate faction relation for %v (%v) and %v (%v)\n",
					r.FactionId2, factionTags[r.FactionId2], r.FactionId1, factionTags[r.FactionId1])
			}
		} else {
			reputations[r.FactionId2] = map[int64]int{}
		}
		reputations[r.FactionId2][r.FactionId1] = r.Reputation
	}

	fmt.Printf("Reputations (%v / %v):\n", len(v.Relations), len(reputations))
	for f1, r := range reputations {
		for f2, reputation := range r {
			fmt.Printf("- %v/%v: %v\n", factionTags[f1], factionTags[f2], reputation)
		}
	}
	return nil
}
