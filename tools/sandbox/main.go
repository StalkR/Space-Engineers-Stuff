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
	sandboxFlag = flag.String("sandbox", "", "Path to Sandbox.sbc to process.")

	factionsFlag = flag.Bool("factions", false, "Analyze factions.")
)

func launch() error {
	if *factionsFlag {
		return handleFactions()
	}
	return errors.New("no action flag?")
}
