﻿
AsymmetricalInterfaces
CoopRPG
TouchscreenSteamed
CoopThoughts
* 
#Other

+Pitch
A game for action-oriented kids (8+) and parents to bond via learning to coordinate and overcoming a shared challenge

Fun found! After about eight hours.

+Time
4h hitscan incl. video and refactoring
20m add more cannon
2h40 cannon recoil
15m UI design
1h25m mouse movement
25 laser gfx
1h35 iOs build
2h45 compass movement
1h technical bullshit
45m score display

NEXT improve asteroid movement patterns

+Cannon
You can have it alternate evenly (ta ta ta ta) or in bursts (ti taya ti taya). The movie does the former.
You can have it recoil, or shoot when it reaches forward extension. The movie does the latter.
You can have it recoil cubically or lerp. The movie lerps.
Movie firing rate is about 0.7 per battery, so 0.35 between shots... but in other scenes, where you can't see the cannon, the beams fly out like crazy
They are actually projectiles, not beams, in the film. Can we make projectiles not suck?

++Controls
+++Autoshoot
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
 
+++Movement
 * Swipe to turn
 * Hold the device in front of you, turn your body to keep the target in view, autoshoot as above
  * rotation only? Could feel weird. 
  * Won't work on phones or tablet, just VR :(
  * No, it is possible -- your planets app does it! Use compass instead of accel
 * Tilt the device to rotate or add rotational acceleration
 * VR -- turn your body (sit in a spinning chair for the best experience)
Since restricting the movement range doesn't work with physical turning of the body, imagine the gunner as being in a ball turret on the top of bottom of the ship and actually render the ship (with collision object) below/above. Don't shoot if it would hit the ship. People will tend not to look up when moving their bodies anyway, since craning the neck is awkward.

It is pretty fun to only be able to rotate around up and forward axis, so to move up and down you have to roll and then yaw instead of just pitching.

Shooting at nearby targets the swoop by fast captures the feeling much better than distant targets (which are fiddly, but not exciting, because little movement is needed).

+Thoughts

http://www.liveforfilms.com/wp-content/uploads/2010/11/falcon2.jpg
https://www.youtube.com/watch?v=T_OSeRxhGOY 2:01
file://localhost/Users/rafael/Downloads/Falcon8.swf


P1 pilots the ship, p2 and optionally more are gunners. Dirt simple "AI", really just autoplayer, to fill empty seat if needed: p1 flies randomly, p2 has an n% chance to damage any unblocked) enemy target each second.

Unlike steamed, positioning the gunner to get a good shot in isn't very relevant, since the only thing that can go wrong is that the ship blocks the target (simulated by limiting the rotation angle of P2 of just putting a big simple object above P2).

So we need another goal: dodging asteroids, perhaps, or heat seeking missiles. But is there enough interaction between the players then?

In the movie, the guns can only tilt in a limited range, so they need the pilot there. Maybe there's something there.

++P1 Controls
+++2D
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
2.9. Tilt

+++3D
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

++P2 Controls
+++3D
1. Drag finger to rotate in the direction the line drawn points to (drag up to rotate around x-axis, up and left to rotate around x=y). Bigger drag is faster rotation.
2. Rotate in direction of touch (as 1, with implicit line between touch and center)
2.1. Constant rotation speed (over smallest angle to touch)
2.2. Constant angular acceleration (over smallest angle to touch)
3. Tilt