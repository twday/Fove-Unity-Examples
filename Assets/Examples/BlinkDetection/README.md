# Blink Detection
## An example demonstrating blink detection
This example shows how the CheckEyesClosed() function can be used in conjunction with a timer to detect whether the user has blinked.

### Scenes
#### BlinkDetection.unity
The example scene file

### Scripts
#### DetectBlink.cs
This script detects whether the use has blinked.
##### *float* blinkThreshold
The maximum time threshold for a blink to occur
##### *Light* blinkLight
A light with in the scene controlled by the user's blinking
