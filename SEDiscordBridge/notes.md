# Notes on Bish's SEDiscordBridge plugin

- plugin: https://torchapi.net/plugins/item/3cd3ba7f-c47c-4efe-8cf1-bd3f618f5b9c
- code: https://github.com/Bishbash777/SEDB-RELOADED
- backend for steam/discord linking: http://sedb.uk/

## Query database
```
curl -d DATA=steamid -d GUID=3cd3ba7f-c47c-4efe-8cf1-bd3f618f5b9c -d FUNCTION=get_discord_id -d API_KEY=TEST_KEY 'http://sedb.uk/api/index.php'
curl -d DATA=steamid -d GUID=3cd3ba7f-c47c-4efe-8cf1-bd3f618f5b9c -d FUNCTION=get_discord_name -d API_KEY=TEST_KEY 'http://sedb.uk/api/index.php'
```

## Insert SteamID

### Get a GUID
```
curl -si -d 'steamid=1337' 'http://sedb.uk/discord/guid-manager.php'
existance=false&guid=914A135F-B51D-491F-B3D4-E38AFB5C385C
```

### Get session
```
curl -i 'http://sedb.uk/?guid=914A135F-B51D-491F-B3D4-E38AFB5C385C&steamid=1337'
Set-Cookie: PHPSESSID=xxx; path=/
Set-Cookie: client=a%3A2%3A%7Bs%3A7%3A%22steamid%22%3Bs%3A4%3A%221337%22%3Bs%3A4%3A%22guid%22%3Bs%3A36%3A%22914A135F-B51D-491F-B3D4-E38AFB5C385C%22%3B%7D
Location: https://discord.com/api/oauth2/authorize?client_id=714454685456793714&redirect_uri=http%3A%2F%2Fsedb.uk%2F&response_type=code&scope=identify%20email%20guilds
```

### Identify on discord and get code

### Insert SteamID
```
curl -i -H 'Cookie: PHPSESSID=xxx; client=xxx' 'http://sedb.uk/?code=xxx'
Location: success/index.php

client= is serialized PHP
a:2:{s:7:"steamid";s:4:"1337";s:4:"guid";s:36:"914A135F-B51D-491F-B3D4-E38AFB5C385C";}
```
