package main

type MyObjectBuilder_Checkpoint struct {
	Factions   []MyObjectBuilder_Faction  `xml:"Factions>Factions>MyObjectBuilder_Faction"`
	Players    []item                     `xml:"Factions>Players>dictionary>item"`
	Identities []MyObjectBuilder_Identity `xml:"Identities>MyObjectBuilder_Identity"`
}

type MyObjectBuilder_Faction struct {
	FactionId int64                           `xml:"FactionId"`
	Tag       string                          `xml:"Tag"`
	Name      string                          `xml:"Name"`
	Members   []MyObjectBuilder_FactionMember `xml:"Members>MyObjectBuilder_FactionMember"`
}

type MyObjectBuilder_FactionMember struct {
	PlayerId  int64 `xml:"PlayerId"` // = IdentityId
	IsLeader  bool  `xml:"IsLeader"`
	IsFounder bool  `xml:"IsFounder"`
}

type MyObjectBuilder_Identity struct {
	IdentityId     int64  `xml:"IdentityId"`
	DisplayName    string `xml:"DisplayName"`
	LastLoginTime  string `xml:"LastLoginTime"`
	LastLogoutTime string `xml:"LastLogoutTime"`
}

type item struct {
	Key   int64 `xml:"Key"`
	Value int64 `xml:"Value"`
}
