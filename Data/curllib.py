import urllib2
import os
import time

url = "http://img.pokemondb.net/sprites/black-white/anim/"

f = open("pokemon.txt", 'r')

names = []

newline = '\n'
for i,entry in enumerate(map(lambda x: x.strip().split(newline), f.read().split('[')[1:])):
    
    for line in entry[1:]:
        [k, v] = line.split('=')
        if k == "Name":
        	names.append((i+1, v.lower()))
f.close()

for i, name in names:

	# fuck these pokemon in particular :
	# nidoran male/female 
	# farfetch'd
	# mr. mime
	# mime jr.

	# Eerste zoveel zijn binnen
	if i <= 439:
		continue

	url_n = url + "normal/"
	f1 = open("Animations/" + str(i).zfill(3) + ".gif",'wb')
	f1.write( urllib2.urlopen(url_n + name + ".gif").read() )
	f1.close()

	time.sleep(1)

	url_n = url + "shiny/"
	f1 = open("Animations/" + str(i).zfill(3) + "s.gif",'wb')
	f1.write( urllib2.urlopen(url_n + name + ".gif").read() )
	f1.close()

	time.sleep(1)

	url_n = url + "back-normal/"
	f1 = open("Animations/" + str(i).zfill(3) + "b.gif",'wb')
	f1.write( urllib2.urlopen(url_n + name + ".gif").read() )
	f1.close()

	time.sleep(1)

	url_n = url + "back-shiny/"
	f1 = open("Animations/" + str(i).zfill(3) + "sb.gif",'wb')
	f1.write( urllib2.urlopen(url_n + name + ".gif").read() )
	f1.close()

	time.sleep(1)
