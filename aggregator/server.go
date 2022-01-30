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
    return fmt.Errorf("invalid header: got %v want %v", header, A2S_HEADER)
  }
  var kind uint8
  kind, b = read_u8(b)

  switch kind {
  case A2S_INFO:
    var payload string
    payload, b = read_cstring(b)
    if payload != A2S_INFO_PAYLOAD {
      return fmt.Errorf("invalid payload: got %v want %v", payload, A2S_INFO_PAYLOAD)
    }
    if _, err := conn.WriteTo(s.data.Info().Bytes(), addr); err != nil {
      return fmt.Errorf("write info: %v", err)
    }
    return nil

  case A2S_PLAYER:
    if _, err := conn.WriteTo(s.data.Players().Bytes(), addr); err != nil {
      return fmt.Errorf("write players: %v", err)
    }
    return nil
  }
  return fmt.Errorf("unhandled packet kind: %v", kind)
}
