#!/usr/bin/env python3
# Watch apps for changes and get notified via discord webhook.

import logging
import os
import time
import urllib.parse
import urllib.request

from steam import client
from steam import enums
from steam.client import cdn

APPS = {
  244850: 'Space Engineers',
  298740: 'Space Engineers Dedicated Server',
}

def main():
  logging.basicConfig(level=logging.INFO, format='%(asctime)s %(message)s', datefmt='%Y-%m-%d %H:%M:%S')

  s = client.SteamClient()
  s.anonymous_login()
  cdnc = cdn.CDNClient(s)

  change_number = 0
  while True:
    r = s.get_changes_since(change_number, True, False)
    if r.force_full_update or r.force_full_app_update:
      change_number = r.current_change_number
      logging.info('[!] full app update, new change number: %i', change_number)
      continue
    logging.info('[*] changes between %i and %i: %i', change_number, r.current_change_number, len(r.app_changes))
    change_number = r.current_change_number
    changes = [c.appid for c in r.app_changes if c.appid in APPS]
    if changes:
      notify('Steam update: %s' % ', '.join('[%s](<https://steamdb.info/app/%i/>)' % (APPS[i], i) for i in changes))
    time.sleep(60)

def notify(msg):
  logging.info('[+] %s', msg)
  webhook = os.getenv('WEBHOOK')
  if not webhook:
    return
  data = urllib.parse.urlencode({'content': msg})
  headers = {'User-Agent': 'curl/8.7.1'}  # discord 403s urllib's
  urllib.request.urlopen(urllib.request.Request(webhook, data.encode('utf-8'), headers=headers))

if __name__ == '__main__':
  main()
