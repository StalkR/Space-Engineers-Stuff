package main

import (
	"fmt"
	"log"
	"net"
	"sort"
	"strings"
	"time"
)

func query(host string) error {
	info, err := queryInfo(host)
	if err != nil {
		return err
	}
	players, err := queryPlayers(host)
	if err != nil {
		return err
	}
	if *flagLog {
		var playerNames []string
		for _, p := range players {
			playerNames = append(playerNames, p.Name)
		}
		sort.Strings(playerNames)
		log.Printf("%v (%v): %v", info.Name, info.Players, strings.Join(playerNames, ", "))
	} else {
		fmt.Printf("      Server: %v\n", info.Name)
		fmt.Printf("         Map: %v\n", info.MapName)
		fmt.Printf("      Folder: %v\n", info.Folder)
		fmt.Printf("        Game: %v\n", info.Game)
		fmt.Printf("       AppID: %v\n", info.AppID)
		fmt.Printf("     Players: %v\n", info.Players)
		fmt.Printf("  MaxPlayers: %v\n", info.MaxPlayers)
		fmt.Printf("        Bots: %v\n", info.Bots)
		fmt.Printf("        Type: %c\n", info.ServerType)
		fmt.Printf(" Environment: %c\n", info.Environment)
		fmt.Printf("  Visibility: %v\n", info.Visibility)
		fmt.Printf("         VAC: %v\n", info.VAC)
		fmt.Printf("     Version: %v\n", info.Version)
		fmt.Printf("         EDF: %v\n", info.EDF)
		fmt.Printf("Player names: %v\n", len(players))
		for _, p := range players {
			fmt.Printf(" - %v (score: %v, since: %v)\n", p.Name, p.Score, time.Duration(p.Duration)*time.Second)
		}
	}
	return nil
}

const timeout = 5 * time.Second

func queryInfo(host string) (*ServerInfo, error) {
	conn, err := net.DialTimeout("udp", host, timeout)
	if err != nil {
		return nil, err
	}
	defer conn.Close()
	conn.SetReadDeadline(time.Now().Add(timeout))

	var b []byte
	var challenge uint32

	for i := 0; i < 5; i++ {
		if _, err := conn.Write(INFO_Request(challenge)); err != nil {
			return nil, err
		}

		b = make([]byte, PACKET_SIZE)
		n, err := conn.Read(b)
		if err != nil {
			return nil, err
		}
		b = b[:n]
		var header uint32
		header, b = read_u32(b)
		if header != A2S_HEADER {
			return nil, fmt.Errorf("invalid header: got %v want %v", header, A2S_HEADER)
		}
		var kind uint8
		kind, b = read_u8(b)
		if kind == A2S_CHALLENGE {
			challenge, b = read_u32(b)
			continue
		}
		if kind != A2S_INFO_RESPONSE {
			return nil, fmt.Errorf("invalid response: got %v want %v", kind, A2S_INFO_RESPONSE)
		}
		break
	}

	var r ServerInfo
	r.Protocol, b = read_u8(b)
	if r.Protocol != A2S_INFO_PROTOCOL {
		return nil, fmt.Errorf("unexpected protocol: got %v want %v", r.Protocol, A2S_INFO_PROTOCOL)
	}
	r.Name, b = read_cstring(b)
	r.MapName, b = read_cstring(b)
	r.Folder, b = read_cstring(b)
	r.Game, b = read_cstring(b)
	r.AppID, b = read_u16(b)
	r.Players, b = read_u8(b)
	r.MaxPlayers, b = read_u8(b)
	r.Bots, b = read_u8(b)
	r.ServerType, b = read_u8(b)
	r.Environment, b = read_u8(b)
	r.Visibility, b = read_u8(b)
	r.VAC, b = read_u8(b)
	r.Version, b = read_cstring(b)
	r.EDF, b = read_u8(b)
	if r.EDF&0x80 != 0 {
		r.Port, b = read_u16(b)
	}
	if r.EDF&0x10 != 0 {
		r.SteamID, b = read_u64(b)
	}
	if r.EDF&0x40 != 0 {
		r.SpectatorPort, b = read_u16(b)
		r.SpectatorName, b = read_cstring(b)
	}
	if r.EDF&0x20 != 0 {
		r.Keywords, b = read_cstring(b)
	}
	if r.EDF&0x01 != 0 {
		r.GameID, b = read_u64(b)
	}
	return &r, nil
}

func queryPlayers(host string) (ServerPlayers, error) {
	conn, err := net.DialTimeout("udp", host, time.Second)
	if err != nil {
		return nil, err
	}
	defer conn.Close()

	var b []byte
	var challenge uint32

	for i := 0; i < 5; i++ {
		if _, err := conn.Write(PLAYER_Request(challenge)); err != nil {
			return nil, err
		}

		b := make([]byte, PACKET_SIZE)
		n, err := conn.Read(b)
		if err != nil {
			return nil, err
		}
		b = b[:n]
		var header uint32
		header, b = read_u32(b)
		if header != A2S_HEADER {
			return nil, fmt.Errorf("invalid header: got %v want %v", header, A2S_HEADER)
		}
		var kind uint8
		kind, b = read_u8(b)
		if kind == A2S_CHALLENGE {
			challenge, b = read_u32(b)
			continue
		}
		if kind != A2S_PLAYER_RESPONSE {
			return nil, fmt.Errorf("invalid response: got %v want %v", kind, A2S_INFO_RESPONSE)
		}
		break
	}

	var list ServerPlayers
	var total uint8
	total, b = read_u8(b)
	for i := 0; i < int(total); i++ {
		var p ServerPlayer
		p.Index, b = read_u8(b)
		p.Name, b = read_cstring(b)
		p.Score, b = read_u32(b)
		p.Duration, b = read_f32(b)
		list = append(list, &p)
	}
	return list, nil
}
