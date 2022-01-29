package main

import (
  "bytes"
  "encoding/binary"
)

const (
  PACKET_SIZE         = 1400
  A2S_HEADER          = uint32(0xffffffff)
  A2S_CHALLENGE       = uint8(0x41)
  A2S_INFO            = uint8(0x54)
  A2S_INFO_PAYLOAD    = "Source Engine Query"
  A2S_INFO_RESPONSE   = uint8(0x49)
  A2S_INFO_PROTOCOL   = uint8(0x11)
  A2S_PLAYER          = uint8(0x55)
  A2S_PLAYER_RESPONSE = uint8(0x44)
)

func p8(n uint8) string { return string([]byte{n}) }

func p32(n uint32) string {
  var b []byte
  for i := uint32(0); i < 4; i++ {
    b = append(b, byte((n>>(8*i))&0xff))
  }
  return string(b)
}

func read_u8(data []byte) (uint8, []byte) {
  if len(data) < 1 {
    return 0, nil
  }
  return data[:1][0], data[1:]
}

func read_u16(data []byte) (uint16, []byte) {
  if len(data) < 2 {
    return 0, nil
  }
  return uint16(data[0]) + uint16(data[1])<<8, data[2:]
}

func read_u32(data []byte) (uint32, []byte) {
  if len(data) < 4 {
    return 0, nil
  }
  var n uint32
  for i := uint32(0); i < 4; i++ {
    n += uint32(data[i]) << (8 * i)
  }
  return n, data[4:]
}

func read_u64(data []byte) (uint64, []byte) {
  if len(data) < 8 {
    return 0, nil
  }
  var n uint64
  for i := uint64(0); i < 8; i++ {
    n += uint64(data[i]) << (8 * i)
  }
  return n, data[8:]
}

func read_f32(data []byte) (float32, []byte) {
  if len(data) < 4 {
    return 0, nil
  }
  var f float32
  binary.Read(bytes.NewReader(data), binary.LittleEndian, &f)
  return f, data[4:]
}

func read_cstring(data []byte) (string, []byte) {
  p := bytes.IndexByte(data, 0)
  if p == -1 {
    return "", nil
  }
  return string(data[:p]), data[p+1:]
}

func CHALLENGE_Response(challenge uint32) []byte {
  return []byte(p32(A2S_HEADER) + p8(A2S_CHALLENGE) + p32(challenge))
}

func INFO_Request(challenge uint32) []byte {
  return []byte(p32(A2S_HEADER) + p8(A2S_INFO) + A2S_INFO_PAYLOAD + "\x00" + p32(challenge))
}

func PLAYER_Request(challenge uint32) []byte {
  return []byte(p32(A2S_HEADER) + p8(A2S_PLAYER) + p32(challenge))
}

type ServerInfo struct {
  Protocol      uint8
  Name          string
  MapName       string
  Folder        string
  Game          string
  AppID         uint16
  Players       uint8
  MaxPlayers    uint8
  Bots          uint8
  ServerType    uint8
  Environment   uint8
  Visibility    uint8
  VAC           uint8
  Version       string
  EDF           uint8
  Port          uint16
  SteamID       uint64
  SpectatorPort uint16
  SpectatorName string
  Keywords      string
  GameID        uint64
}

func (s ServerInfo) Bytes() []byte {
  var b bytes.Buffer
  binary.Write(&b, binary.LittleEndian, A2S_HEADER)
  binary.Write(&b, binary.LittleEndian, A2S_INFO_RESPONSE)
  binary.Write(&b, binary.LittleEndian, A2S_INFO_PROTOCOL)
  b.WriteString(s.Name + "\x00")
  b.WriteString(s.MapName + "\x00")
  b.WriteString(s.Folder + "\x00")
  b.WriteString(s.Game + "\x00")
  binary.Write(&b, binary.LittleEndian, s.AppID)
  binary.Write(&b, binary.LittleEndian, s.Players)
  binary.Write(&b, binary.LittleEndian, s.MaxPlayers)
  binary.Write(&b, binary.LittleEndian, s.Bots)
  binary.Write(&b, binary.LittleEndian, s.ServerType)
  binary.Write(&b, binary.LittleEndian, s.Environment)
  binary.Write(&b, binary.LittleEndian, s.Visibility)
  binary.Write(&b, binary.LittleEndian, s.VAC)
  b.WriteString(s.Version + "\x00")
  binary.Write(&b, binary.LittleEndian, s.EDF)
  if s.EDF&0x80 != 0 {
    binary.Write(&b, binary.LittleEndian, s.Port)
  }
  if s.EDF&0x10 != 0 {
    binary.Write(&b, binary.LittleEndian, s.SteamID)
  }
  if s.EDF&0x40 != 0 {
    binary.Write(&b, binary.LittleEndian, s.SpectatorPort)
    b.WriteString(s.SpectatorName + "\x00")
  }
  if s.EDF&0x20 != 0 {
    b.WriteString(s.Keywords + "\x00")
  }
  if s.EDF&0x01 != 0 {
    binary.Write(&b, binary.LittleEndian, s.GameID)
  }
  return b.Bytes()
}

type ServerPlayer struct {
  Index    uint8
  Name     string
  Score    uint32
  Duration float32
}

func (s ServerPlayer) Bytes() []byte {
  var b bytes.Buffer
  binary.Write(&b, binary.LittleEndian, s.Index)
  b.WriteString(s.Name + "\x00")
  binary.Write(&b, binary.LittleEndian, s.Score)
  binary.Write(&b, binary.LittleEndian, s.Duration)
  return b.Bytes()
}

type ServerPlayers []*ServerPlayer

func (s ServerPlayers) Bytes() []byte {
  var b bytes.Buffer
  binary.Write(&b, binary.LittleEndian, A2S_HEADER)
  binary.Write(&b, binary.LittleEndian, A2S_PLAYER_RESPONSE)
  binary.Write(&b, binary.LittleEndian, uint8(len(s)))
  for _, p := range s {
    b.Write(p.Bytes())
  }
  return b.Bytes()
}
