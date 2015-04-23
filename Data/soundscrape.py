import urllib2
import os
import time
import re

soundlist = urllib2.urlopen("http://downloads.khinsider.com/game-soundtracks/album/pokemon-gameboy-sound-collection").read()

for i in range(101, 146):
	baseurl = "http://downloads.khinsider.com/game-soundtracks/album/pokemon-gameboy-sound-collection/"
	p = re.compile(baseurl + str(i) + "([^\"]+)")
	m = p.search(soundlist)
	name = m.group(1)
	url = baseurl + str(i) + name
	soundpage = urllib2.urlopen(url).read()
	p = re.compile("<audio id=\"audio1\" src=\"([^>]+)\" controls preload=\"auto\" autobuffer>")
	m = p.search(soundpage)
	actualurl = m.group(1)
	f1 = open("Sounds/Music/" + str(i) + name,'wb')
	f1.write( urllib2.urlopen(actualurl).read() )
	f1.close()