#!/usr/bin/env python

#import libraries
import sys
import time
import subprocess

#import Spacebrew
from pySpacebrew.spacebrew import Spacebrew

#create Spacebrew object
brew = Spacebrew("MRHT_Micol_Joyfishing", description="The IMU Unit wasn't giving back sensed data so we decided to use the joystick",  server="192.168.1.165", port=9000)

#to use Pi as an OUTPUT
        #brew.addSubscriber("name", "type")

#to use Pi as an INPUT
brew.addPublisher("up", "boolean")
brew.addPublisher("down", "boolean")
brew.addPublisher("left", "boolean")
brew.addPublisher("left", "boolean")

brew.addPublisher("buttonPress", "boolean")

#define state of the Pi, initially it is not connected
connected = False

#import SenseHat library and create an object
from sense_hat import SenseHat
sense = SenseHat()
sense.clear()

#define a frequency to which you want to listent to the Pi
CHECK_FREQ = 1.5 

#start connection with spacebrew
try:
    brew.start()
    print("Press Ctrl-C to quit.")

    #loop to get continuous data from Pi's IMU Unit
    while True:
        #loop function to check for joystick events
        for event in sense.stick.get_events():
            #if an event is found check what was pressed
            print(event.action)
            print(event.direction)
            #the directions read by Pi are adjusted to the orientation in which the Pi is held
            if event.direction == "left":
                brew.publish("up", True)
            elif (event.direction == "up"):
                brew.publish("right", True)
            elif (event.direction == "right"):
                brew.publish("down", True)
            elif (event.direction == "down"):
                brew.publish("left", True)
            elif (event.direction == "middle"):
                brew.publish("buttonPressed", True)
        #delay to read again
        time.sleep(CHECK_FREQ)
        sense.clear

#function that runs once pressed Ctrl-C
finally:
    brew.stop()