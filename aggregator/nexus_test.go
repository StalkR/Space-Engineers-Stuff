package main

import (
	"encoding/xml"
	"reflect"
	"testing"
)

func TestParseNexusConfig(t *testing.T) {
	const config = `<?xml version="1.0" encoding="utf-8"?>
<Config xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
  <ConfiguredServers>
    <Server>
      <Name>Lobby</Name>
      <IPAddress>1.2.3.4</IPAddress>
      <Port>27015</Port>
    </Server>
    <Server>
      <Name>Server</Name>
      <IPAddress>5.6.7.8</IPAddress>
      <Port>27016</Port>
    </Server>
  </ConfiguredServers>
</Config>`
	var v nexusConfig
	if err := xml.Unmarshal([]byte(config), &v); err != nil {
		t.Fatalf("xml decode error: %v", err)
	}
	got, err := parseNexusConfig(&v)
	if err != nil {
		t.Fatalf("parseNexusConfig error: %v", err)
	}
	want := []string{"1.2.3.4:27015", "5.6.7.8:27016"}
	if !reflect.DeepEqual(got, want) {
		t.Errorf("servers: got %v, want %v", got, want)
	}
}
