import urllib2
import os
import time

url = "http://www.pokestadium.com/tools/sprites/sprites/xy/"

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

	if i == 29:
		name = "nidoran-f"
	elif i == 32:
		name = "nidoran-m"
	elif i == 83:
		name = "farfetchd"
	elif i == 122:
		name = "mr-mime"
	elif i == 439:
		name = "mime-jr"

	# fuck deoxys and his forms
	if i == 386:
		name = "deoxys-normal"
	# and fuck Wormadam. Thats not even a real pokemon
	elif i == 413:
		name = "wormadam-plant"
	# srsly fuck forms
	elif i == 479:
		name = "rotom-normal"
	elif i == 487:
		name = "giratina-altered"
	elif i == 492:
		name = "shaymin-land"
	elif i == 555:
		name = "darmanitan-standard"
	elif i == 648:
		name = "meloetta-aria"

	f1 = open("Graphics/Gen6Animations/" + str(i).zfill(3) + ".gif",'wb')
	f1.write( urllib2.urlopen(url + name.lower() + ".gif").read() )
	f1.close()

	time.sleep(1)
