import urllib2
import os
import time

url = "http://www.pokestadium.com/sprites/xy/"

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
		name = "nidoranf"
	elif i == 32:
		name = "nidoranm"
	elif i == 83:
		name = "farfetchd"
	elif i == 122:
		name = "mr-mime"
	elif i == 439:
		name = "mime-jr"
	name = name.lower()

	try:
		f1 = open("Graphics/Gen6Animations/" + str(i).zfill(3) + ".gif",'wb')
		f1.write( urllib2.urlopen(url + name + ".gif").read() )
		f1.close()
		time.sleep(1)
	except urllib2.HTTPError, e:
		print name + " not found"

	try:
		handle = urllib2.urlopen(url + "back/" + name + ".gif")
		f1 = open("Graphics/Gen6Animations/" + str(i).zfill(3) + "b.gif",'wb')
		f1.write( handle.read() )
		f1.close()
		time.sleep(1)
	except urllib2.HTTPError, e:
		print name + " back not found"

	try:
		handle = urllib2.urlopen(url + "shiny/" + name + ".gif")
		f1 = open("Graphics/Gen6Animations/" + str(i).zfill(3) + "s.gif",'wb')
		f1.write( handle.read() )
		f1.close()
		time.sleep(1)
	except urllib2.HTTPError, e:
		print name + " shiny not found"

	try:
		handle = urllib2.urlopen(url + "shiny/back/" + name + ".gif")
		f1 = open("Graphics/Gen6Animations/" + str(i).zfill(3) + "sb.gif",'wb')
		f1.write( handle.read() )
		f1.close()
		time.sleep(1)
	except urllib2.HTTPError, e:
		print name + " shiny back not found"

	n = 2
	while (True):
		try:
			handle = urllib2.urlopen(url + name + "-" + str(n) + ".gif")
			f1 = open("Graphics/Gen6Animations/" + str(i).zfill(3) + "-" + str(n) + ".gif",'wb')
			f1.write( handle.read() )
			f1.close()
			time.sleep(1)
		except urllib2.HTTPError, e:
			print name + " has " + str(n - 2) + " attacks"
			break
		n = n + 1
	
