# Cubefield Arduino Prototype

# Project Description
This repo is a clone prototype of "Cubefield," a game I used to play in school when I was younger. I have a bunch of arduinos and electronic components for DIY projects that I haven't done much with, so I decided I wanted to learn how to use an Arduino UNO with a joystick module to control movement in a Unity project. I figured a fun little game to code would be Cubefield. 

# Setup
## Uploading the arduino code to your arduino
Included in this repo is "JoystickMovement.ino" which contains the code to upload onto your arduino. This file includes some logic for remapping the joystick input to stay in a range of -100 to 100 for both the x and y joystick axes. You may need to change this logic depending on your joystick module and your preference toward the input range of the axes. This logic was a bit finicky for me to get working right, as my module's origin and range was a bit inconvenient to work with.

## Configuring the Unity project
This Unity project's version is 2020.3.15f2. It may work in earlier or later versions of Unity, but I haven't tested that. Make sure that Project Settings -> Player -> Configuration -> API Compatiibility Level is set to .NET 4.x, otherwise you will likely have a compiler error and won't be able to run the game. This API level was needed for me to access the System.IO.Ports library.

## About the Game
Note that (so far) the game logic that I've written for the Cubefield clone is very scrappy, as this was just a prototype for me to learn how to hook the arduino data into Unity. I'll clean up the code (soon) and improve the game a bit more before I consider this project completed.