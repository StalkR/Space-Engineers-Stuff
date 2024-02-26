package main

import (
	"fmt"
	"log"
	"net"
)

type ServerData interface {
	Info() *ServerInfo
	Players() ServerPlayers
}

type Server struct {
	data ServerData
}

func NewServer(data ServerData) *Server {
	return &Server{data: data}
}

func (s *Server) ListenAndServe(addr string) error {
	socket, err := net.ListenPacket("udp", addr)
	if err != nil {
		return err
	}
	for {
		if err := s.handle(socket); err != nil {
			log.Printf("[-] serve: %v", err)
		}
	}
}

func (s *Server) handle(conn net.PacketConn) error {
	b := make([]byte, PACKET_SIZE)
	n, addr, err := conn.ReadFrom(b)
	if err != nil {
		return fmt.Errorf("read: %v", err)
	}
	b = b[:n]

	var header uint32
	header, b = read_u32(b)
	if header != A2S_HEADER {
		return fmt.Errorf("[%v] invalid header: got %v want %v", addr, header, A2S_HEADER)
	}
	var kind uint8
	kind, b = read_u8(b)

	switch kind {
	case A2S_INFO:
		var payload string
		payload, b = read_cstring(b)
		if payload != A2S_INFO_PAYLOAD {
			return fmt.Errorf("[%v] invalid payload: got %v want %v", addr, payload, A2S_INFO_PAYLOAD)
		}
		if info := s.data.Info(); info != nil {
			log.Printf("[%v] info query: %v players", addr, info.Players)
			if _, err := conn.WriteTo(info.Bytes(), addr); err != nil {
				return fmt.Errorf("[%v] write info: %v", addr, err)
			}
		}
		return nil

	case A2S_PLAYER:
		if _, err := conn.WriteTo(s.data.Players().Bytes(), addr); err != nil {
			return fmt.Errorf("[%v] write players: %v", addr, err)
		}
		return nil
	}
	return fmt.Errorf("[%v] unhandled packet kind: %v", addr, kind)
}
