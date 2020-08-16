Combine with:
[[JuryRigged]]
KesselRun

# Todo
## Compass doesn't work
- Need to set up some permissions in Unity?
- It isn't physically broken, because your other compass app works
- Try on Android?
## Other

* Right now, the game is super fun and starwarsy if you play it as intended, but it is more effective to stand in one place and hold the fire button down.
 * Change asteroid paths: 
  * Falling straight towards you
  * Or curved by gravity, like spacewar
 * Make enemy ships that actively try to avoid the front of you
 * faster asteroid movement towards centre, so some asteroids never make a complete orbit
 * Add friendly ships that you don't want to hit
* Asteroids travel in both directions? 
* Energy for guns competes with energy for shields, like Spacewar?
* VR version!
* Show death screen (from above or turn to face)
* flashing when something gets close
* Fire by saying "pew pew"

# Rejected Ideas
The following would lose the Quad Lasers feel:
 * Lose points for shooting 
 * Slower rate of fire, so autofire tends to miss moving targets
 * Limited ammo, regenerating over time or when you hit an asteroid
 * Instead of fire, do lock-on: you have to stay on target for a second or two, then it fires automatically
 
# Knowledge
## Debug on device
Use unity remote instead, most of the time.

https://docs.unity3d.com/Manual/ManagedCodeDebugging.html
https://www.jetbrains.com/help/rider/Debugging_Unity_Applications.html

Find device IP on iPad system settings
Find port in XCode log, e.g.: Multi-casting "[IP] 10.155.248.128 [Port] 55000 [Flags] 3 [Guid] 1203221529 [EditorId] 2207844580 [Version] 1048832 [Id] iPhonePlayer(Chimpunk):56000 <-- IT IS THIS PART, BUT NORMALLY SEEMS TO BE 56000

Sometimes, Attach to Unity Process is greyed out. Just click the "Run" menu again and it should work.

## Certificate Signing
https://makaka.org/unity-tutorials/test-ios-app-without-developer-account#get-free-ios-developer-account
https://stackoverflow.com/a/47732584

