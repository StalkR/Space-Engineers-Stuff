package main

type MyObjectBuilder_Checkpoint struct {
	Factions       []MyObjectBuilder_Faction         `xml:"Factions>Factions>MyObjectBuilder_Faction"`
	Players        []item                            `xml:"Factions>Players>dictionary>item"`
	Relations      []MyObjectBuilder_FactionRelation `xml:"Factions>Relations>MyObjectBuilder_FactionRelation"`
	Identities     []MyObjectBuilder_Identity        `xml:"Identities>MyObjectBuilder_Identity"`
	AllPlayersData []AllPlayersData                  `xml:"AllPlayersData>dictionary>item"`
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

type MyObjectBuilder_FactionRelation struct {
	FactionId1 int64  `xml:"FactionId1"`
	FactionId2 int64  `xml:"FactionId2"`
	Relation   string `xml:"Relation"`
	Reputation int    `xml:"Reputation"`
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

type AllPlayersData struct {
	Value AllPlayersDataValue `xml:"Value"`
}

type AllPlayersDataValue struct {
	DisplayName          string `xml:"DisplayName"`
	IdentityId           int64  `xml:"IdentityId"`
	Connected            bool   `xml:"Connected"`
	ForceRealPlayer      bool   `xml:"ForceRealPlayer"`
	CreativeToolsEnabled bool   `xml:"CreativeToolsEnabled"`
	RemoteAdminSettings  int    `xml:"RemoteAdminSettings"`
	PromoteLevel         string `xml:"PromoteLevel"`
	BuildColorSlot       int    `xml:"BuildColorSlot"`
	IsWildlifeAgent      bool   `xml:"IsWildlifeAgent"`
}
