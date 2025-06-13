package main

import (
	"errors"
	"flag"
	"log"
)

func main() {
	flag.Parse()
	if err := launch(); err != nil {
		log.Fatal(err)
	}
}

var (
	sandboxFlag     = flag.String("sandbox", "", "Path to Sandbox.sbc to process.")
	playersFileFlag = flag.String("players_file", "", "Path to players.json to resolve IdentityID/SteamID")

	factionsFlag = flag.Bool("factions", false, "Analyze factions.")
	adminsFlag   = flag.Bool("admins", false, "Analyze admins.")
)

func launch() error {
	if *playersFileFlag != "" {
		if err := parsePlayersFile(*playersFileFlag); err != nil {
			return err
		}
	}
	if *factionsFlag {
		return handleFactions()
	}
	if *adminsFlag {
		return handleAdmins()
	}
	return errors.New("no action flag?")
}
