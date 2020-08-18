using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
    public float minOrbitSpeedAtBaseDistance;   // speed up as you get closer, but stop speeding up at base distance
    public float maxOrbitSpeedAtBaseDistance;
    [SerializeField] float approachSpeedAtBaseDistance = 0;  // slow down as you get closer
    [SerializeField] float baseDistance = 0;

    Vector3 orbitCentre;
    float orbitSpeedAtBaseDistance;
    bool isOrbiting;


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
    // TODO Targets that spiral inwards on various great circles. You can see them go by at a distance.
    // TODO Targets that move directly towards the player 
    // TODO Targets that try to strafe the player
    //    Should probably only be able to damage you briefly and/or when close, otherwise feels unfair
    //    But the corresponding benefit is you get more than one chance to hit them
    //    And they move laterally, but not (necessarily) predictably
    //        They could try to avoid your shots, in fact
    void MoveTowards(Vector3 dir, float dist)
    {
        float speedMultiplier = dist / baseDistance;
        GetComponent<Rigidbody>().velocity = dir * approachSpeedAtBaseDistance * speedMultiplier;
    }


    void OrbitAround(Transform tgt)
    {
        orbitCentre = tgt.position;
        orbitSpeedAtBaseDistance = Random.Range(minOrbitSpeedAtBaseDistance, maxOrbitSpeedAtBaseDistance);
        isOrbiting = true;

    }

    void Update()
    {
        if (!isOrbiting) return;
        Vector3 toCentre = (orbitCentre - transform.position);
        float dist = toCentre.magnitude;
        float speedMultiplier = Mathf.Min(1.0f, baseDistance / dist);
        transform.RotateAround(orbitCentre, Vector3.up, orbitSpeedAtBaseDistance * speedMultiplier * Time.deltaTime);
        // 10: You can hold the fire down and stay in place
        // 20 is reasonable, but you have to track
        // 80 you have to wait until they get closer, like 30
        // 120 you can still hit when it gets close
        MoveTowards(toCentre.normalized, dist);
    }

}
