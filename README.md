# controller-ev3-app
Winforms C# program using library Lego.Ev3 by Brian Peek for comfortable EV3 robot controlling.

# Getting started
Before you run .exe file of program you need to:
  * Run Bluetooth on your EV3 robot
  * Connect your robot with PC in Bluetooth on PC
  * Point in config.txt your COM-port and motors(wheels) and hanger(1) op (OutputPorts) (It's located in Debug folder of project)
1 - A thing that hang in itself a videocam (or mobile phone) and rotate to give to camera visibility.

# UI
UI in here is very simple. Winforms form have 50% transparent. Open in whole screen. In corner of screen you can notice robot wheels Speed indicator. That's all!

# Control
So, 
WASD - wheels moving,
Add for add Speed(1), Subtract for subtract Speed of robot, Multiply for invert Speed of robot,
if you hold a left mouse button on screen you can control a hanger
and L... that's L, just L (probably for debug).
1 - Speed it's a indicator on UI, that means power of rotating robot wheels. It's have a range from -100 to 100 (minus just to invert a wheels direction)
