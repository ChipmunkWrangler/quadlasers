
AsymmetricalInterfaces
CoopRPG
TouchscreenSteamed
CoopThoughts
Combine with:
[[JuryRigged]]
KesselRun

[[todo]]
#Pitch
A game for action-oriented kids (8+) and parents to bond via learning to coordinate and overcoming a shared challenge

Fun found! After about eight hours.

# Notes
 The fun, starwarsy part is trying to track a target moving sideways through your field of view. That implies that targets need to stay in your field of view long enough for you to react and/or be predictable enough that you can anticipate them. So they shouldn't come right at you, and they shouldn't be so close and fast that they zip past and you only hit them by luck. OTOH they must move quickly or unpredictably enough that you can't just wait for them to fly in front of you.
 
It is also good to have multiple targets in view at once because it is tempting to switch.
If spinning 360 is allowed, I will do it, but it doesn't actually seem to be optimal (and it makes me dizzy), so a restriction or backstop or enemies that don't show up behind you seem like good ideas.
 
 However, we have a choice between:
    1. Targets that automatically pass through your crosshairs (e.g. spiralling all in the same plane).
        These make it possible to stay in one place and hold down the fire button, which is boring.
        If you decrease fire rate, it because a timing game: fire at the right instant. Better but not the point.
    2. Targets that don't. This implies either
        a) You have a way of figuring out where they are
            Minimap: inelegant, hard to do for a sphere
            Sound: need headphones (not always available and antisocial), and doesn't actually help much, especially in vertical orientation
            TODO Multiplayer: the other player tells you "check your six!" Try simulating with AI. Only works if there are few targets that can be described simply
        b) You don't. The game is then about turning to face the right direction, which is arbitrary and dumb.
            However, if the targets come by more than once in a regular pattern, you might develop a feeling
 TODO targets that spiral in vertical planes
 TODO Targets that try to strafe the player
     Why don't they just attack from the back?
        Maybe they do, but not constantly, because they have to charge, turn, and charge back
        Maybe you can only shoot in one hemisphere, and P2 does the other half
 TODO Targets that avoid the player's crosshairs but have limited maneuverability
    Should probably only be able to damage you briefly and/or when close, otherwise feels unfair
    But the corresponding benefit is you get more than one chance to hit them
    And they move laterally, but not (necessarily) predictably
        They could try to avoid your shots, in fact
 TODO 2d (y=0) targets that move away from crosshairs with limited acceleration (so you can spin fast to overtake them, and it takes them a moment to brake and run the other way)
Remember that the feeling we want is
# Test results
##Waves 1 - 3, 1/s, 20s between waves
Mode 0 (y=0): A bit dizzying, but tolerable. Need a lot of asteroids (5+ per wave, 20 is quite winnable), which increases dizziness because it is worth "sweeping" in one direction for a while, since there are many asteroids in whichever direction you choose. Maybe an early stage? N.B. Holding down the fire button works! It feels dangerous, and you miss a lot, but when the asteroids get close enough, you hit them. 
Mode 1 (as 0 with backstop): Like 1 but less dizzying and a little easier (! this means that spinning isn't actually the best tactic). More than 180 degrees of arc would be nice.
Mode 2 (y in range, horizontal circles): Slightly more dizzing, but still ok. 5 - 10 asteroids is fun, 20 is exciting but I lost. Better than Mode 0 (bzw. more general and useable as difficulty).
Mode 3 (2 with backstop): Better than 1, I think: No dizziness, slightly easier (! I just barely managed 20). However, with high numbers of asteroids I felt like I was getting a lot of lucky shots as they got very close and fast.
Mode 4 (great circles): seasick. Hard: 3 asteroids were already too much.
Mode 5 (4 with backstop): Not bad, not seasick, but very hard and a little frustrating because it is hard to anticpate the orbits.
Mode 6 (as 2 but occasional great circles): Similar to 1, of course. Unsure if it is better. With 10 I am not sure I got one (but of course I could guarantee one per wave). 20 I died.
Mode 7 (as 6 with backstop): Feels pretty cool. No seasickness. Close asteroids feel really fast, but it is possible to get them because you can anticipate their orbits (so a less predictable enemy probably needs to be slower or you need to track them across a wider arc). Pauses between waves maybe a bit long, but having a pause felt good. Occasional "rogue" great circle asteroid is fun. Didn't try to spawn button.

# T Suggestions

Bonus asteroid that doesn't hit you, and when hit, it shows crosshairs (your crosshairs image is missing)
# Targets
* Add friendly ships that you don't want to hit
* Later, when your ship moves, asteroids can travel in straight lines, possibly fragmenting like in classic Asteroids
Shooting at nearby targets that swoop by fast captures the feeling much better than distant targets (which are fiddly, but not exciting, because little movement is needed).
Instead of waves, try creating N (<=2) new targets for each target destroyed (fractional N => keep a running total in the background, or gives the chance of an asteroid being created). 
  Or like Asteroids: split them in half the first time they are hit, then again, and the last ones are destroyed

# Difficulty Rampup
More Asteroids
Faster Asteroids (either faster moving towards center or faster rotation)
Smaller Asteroids
Harder patterns, e.g. 
-higher fractionOfGreatCircles bzw. larger number of guaranteed great circles per wave.
-larger min/maxY

# Misc 
* Add victory screen at end of wave
* Show death screen (from above or turn to face)
* flashing when something gets close for those playing without sound
#Cannon
You can have it alternate evenly (ta ta ta ta) or in bursts (ti taya ti taya). The movie does the former.
You can have it recoil, or shoot when it reaches forward extension. The movie does the latter.
You can have it recoil cubically or lerp. The movie lerps.
Movie firing rate is about 0.7 per battery, so 0.35 between shots... but in other scenes, where you can't see the cannon, the beams fly out like crazy
They are actually projectiles, not beams, in the film. Can we make projectiles not suck?

##Controls
Add full blown star wars targeting system
 
###Movement

P1 pilots the ship, p2 and optionally more are gunners. Dirt simple "AI", really just autoplayer, to fill empty seat if needed: p1 flies randomly, p2 has an n% chance to damage any unblocked) enemy target each second.

Unlike steamed, positioning the gunner to get a good shot in isn't very relevant, since the only thing that can go wrong is that the ship blocks the target (simulated by limiting the rotation angle of P2 of just putting a big simple object above P2).

So we need another goal: dodging asteroids, perhaps, or heat seeking missiles. But is there enough interaction between the players then?

In the movie, the guns can only tilt in a limited range, so they need the pilot there. Maybe there's something there.

##P1 Controls
###2D
1. Thrust: constant, on/off, variable intensity (make these multitouch if they conflict with Rotation)
1.1. Tap to turn thrust on or off
1.2. Hold to thrust, release to stop
1.3. Hold to increase thrust (Accelerate), release to decrease (min = 0)
1.4. Drag up to increase thrust, down to decrease (or in an arc at either lower right or left (if it's the only control, you can allow both at once rather than have player select a handedness preference)).
1.5. Constant
2. Rotation Control schemes (not all are compatible with thrust):
2.1. Drag finger left and right to rotate counterclockwise or clockwise
2.2. Draw an arc ccw or cw to rotate (calculate based on angle to screen center)
2.3. Rotate in direction of touch
2.3.1. Instantly face touch
2.3.2. Constant rotation speed (over smallest angle to touch)
2.3.3. Constant angular acceleration (over smallest angle to touch)
2.3.4. Face touch in fixed time (with transition)
2.8. Touch right / left side of screen to rotate clockwise / ccw.
2.9. Tilt DO THIS FIRST, IT FEELS SO GOOD

###3D
1. Drag finger to rotate in the direction the line drawn points to (drag up to rotate around x-axis, up and left to rotate around x=y). Bigger drag is faster rotation.
2. Rotate in direction of touch (as 1, with implicit line between touch and center)
2.1. Constant rotation speed (over smallest angle to touch)
2.2. Constant angular acceleration (over smallest angle to touch)
3. Tilt
3.1. Around z to bank (steering wheel), x to go up or down
3.2. Around an axis to spin around that axis, so around z spins you but doesn't change heading; y turns left/right
4. Banking Only
4.1. Touch right / left side of screen to bank that way
4.2. Drag in a line or arc 
4.3. Tilt, limited to one axis

##P2 Controls
### Shoot
* Fire by saying "pew pew"
####Autoshoot
This game is more about keeping the target centred long enough, which seems true to the spirit of the film.
Shoot automatically when target is "near"
 * Shoot a ray, shoot whenever it hits
  * But this would always hit (with a beam) or always miss a moving target (projectile)
 * Shoot whenever there is at least one target close enough to the centre of the screen
  * Angle your cannon to point to the centre of the screen, but at the target's distance
   * Don't point right at the target, or you miss moving targets again and can never "lead" them
   * If there are multiple targets
    * aim at the one nearest the center
    * Or the closest one
    * In any case, highlight it to indicate that it is the one being targetted
   * Angling shouldn't really be instant, you should rotate at a constant speed towards the correct point
    * But that might make it very hard in a way that is hard to understand; consider making that a purely visual thing (or not showing the angling at all), simply by making the cannon mesh not angle, just the beam projector.
  * Implementation possibilities:
   * Hang an invisible rectangular prism off the camera, extending up to your max range, with a trigger.
   * Determine the distance of each triggering entity to a cast ray, or a line or line segment (for "closest to center") or to camera (for "closest to you")
Should there be actual "lock on"? 
 * If a ray cast hits the same target for N frames in a row, or N of the last M, it locks on
 * Projectiles seek the locked target
  * Maybe lock on is lost if the target gets too far from the centre, since you don't really want the projectile to curve visibly.
 * Maybe seeking is unnecessary if N is high enough relative to the speed of the projectiles and the distance to the target that "locked on" is just juicy feedback for "a projectile is about to hit".
 * Could also use a raycast for the hit, but show the beam as a very fast projectile
### Rotation
Consider full 3d rotation instead of staying in the plane (yaw only). Maybe just use raw magnetometer for this?
It is pretty fun to only be able to rotate around up and forward axis, so to move up and down you have to roll and then yaw instead of just pitching.
# Rejected Ideas
The following would lose the Quad Lasers feel:
 * Lose points for shooting 
 * Slower rate of fire, so autofire tends to miss moving targets
 * Limited ammo, regenerating over time or when you hit an asteroid
 * Instead of fire, do lock-on: you have to stay on target for a second or two, then it fires automatically
#Thoughts

http://www.liveforfilms.com/wp-content/uploads/2010/11/falcon2.jpg
https://www.youtube.com/watch?v=T_OSeRxhGOY 2:01
file://localhost/Users/rafael/Downloads/Falcon8.swf
