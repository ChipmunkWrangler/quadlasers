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


    // the problem with moving directly towards the player is that the game
    // is then about turning to face the right direction, which is arbitrary in
    // 3d with no minimap, and with a minimap the game would be about staring at
    // the minimap. Sound cues, like in Serious Sam, would work, but not well
    // suited to mobile without headphones.
    // So instead, we orbit the player, not necessarily stably
    // This will involve more visual tracking of asteroids that are moving sideways
    // through your field of view, which is the good stuff.
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
