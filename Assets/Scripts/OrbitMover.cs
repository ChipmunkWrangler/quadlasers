using UnityEngine;

public class OrbitMover : MonoBehaviour
{
    public float minOrbitSpeedAtBaseDistance;   // speed up as you get closer, but stop speeding up at base distance
    public float maxOrbitSpeedAtBaseDistance;
    [SerializeField] public float approachSpeedAtBaseDistance;  // slow down as you get closer
    [SerializeField] public float baseDistance;

    private Vector3 orbitCentre;
    private float orbitSpeedAtBaseDistance;
    private bool isOrbiting;
    private Vector3 orbitAxis;
    // The fun, starwarsy part is trying to track a target moving sideways through your field of view.
    // However, we have a choice between:
    //    1. Targets that automatically pass through your crosshairs (e.g. spiralling all in the same plane).
    //        These make it possible to stay in one place and hold down the fire button, which is boring.
    //        TODO Maybe it is enough to make them faster?
    //    2. Targets that don't. This implies either
    //        a) You have a way of figuring out where they are
    //            Minimap: inelegant, hard to do for a sphere
    //            TODO Sound: need headphones (not always available and antisocial)
    //            TODO Multiplayer: the other player tells you "check your six!"
    //        b) You don't. The game is then about turning to face the right direction, which is arbitrary and dumb.
    //            However, if the targets come by more than once in a regular pattern, you might develop a feeling
    // I tried targets that spiral inwards on random great circles, but it made me seasick.
    // I tried targets in the horizontal plane, but at varying heights. This is less sickening, but the most effective approach is to face directly up or down and tip slightly... not satisfying
    // TODO targets that spiral in vertical planes
    // TODO Targets that move directly towards the player 
    // TODO Targets that try to strafe the player
    //     Why don't they just attack from the back?
    //        Maybe they do, but not constantly, because they have to charge, turn, and charge back
    //        Maybe you can only shoot in one hemisphere, and P2 does the other half
    // TODO Targets that avoid the player's crosshairs but have limited maneuverability
    //    Should probably only be able to damage you briefly and/or when close, otherwise feels unfair
    //    But the corresponding benefit is you get more than one chance to hit them
    //    And they move laterally, but not (necessarily) predictably
    //        They could try to avoid your shots, in fact
    private void MoveTowards(Vector3 dir, float dist)
    {
        float speedMultiplier = dist / baseDistance;
        GetComponent<Rigidbody>().velocity = dir * approachSpeedAtBaseDistance * speedMultiplier;
    }

    private void OrbitAround(OrbitData orbitData)
    {
        orbitCentre = orbitData.Midpoint;
        orbitSpeedAtBaseDistance = Random.Range(minOrbitSpeedAtBaseDistance, maxOrbitSpeedAtBaseDistance);
        isOrbiting = true;
        orbitAxis = orbitData.Axis;
    }

    private Vector3 getVectorToCentre()
    {
        return orbitCentre - transform.position;
    }

    private void Update()
    {
        // TODO Try replacing this with gravity plus an initial momentum
        if (!isOrbiting) return;
        var toCentre = getVectorToCentre();
        var dist = toCentre.magnitude;
        var speedMultiplier = Mathf.Min(1.0f, baseDistance / dist);
        var angleToMove = orbitSpeedAtBaseDistance * speedMultiplier * Time.deltaTime;
        transform.RotateAround(orbitCentre, orbitAxis, angleToMove);
        // 10: You can hold the fire down and stay in place
        // 20 is reasonable, but you have to track
        // 80 you have to wait until they get closer, like 30
        // 120 you can still hit when it gets close
        MoveTowards(toCentre.normalized, dist);
    }

}
