package main

import (
	"path/filepath"
	"reflect"
	"testing"
)

func TestParseNexus1Config(t *testing.T) {
	got, err := parseNexus1ConfigFile(filepath.Join("testdata", "nexus1.cfg"))
	if err != nil {
		t.Fatalf("parseNexus1Config error: %v", err)
	}
	want := []string{"1.2.3.4:27015", "5.6.7.8:27016"}
	if !reflect.DeepEqual(got, want) {
		t.Errorf("servers: got %v, want %v", got, want)
	}
}

func TestParseNexus3Config(t *testing.T) {
	got, err := parseNexus3ConfigFile(filepath.Join("testdata", "nexus3.cfg"))
	if err != nil {
		t.Fatalf("parseNexus3Config error: %v", err)
	}
	want := []string{"1.2.3.4:27015", "5.6.7.8:27016"}
	if !reflect.DeepEqual(got, want) {
		t.Errorf("servers: got %v, want %v", got, want)
	}
}
