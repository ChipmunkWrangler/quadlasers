using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float minSecsPerOrbit;
	public float maxSecsPerOrbit;
	[SerializeField] float approachSpeedAtBaseDistance;
	[SerializeField] float baseDistance;

	Vector3 orbitCentre;
	float secsPerOrbit;
	bool isOrbiting;


	// the problem with moving directly towards the player is that the game
	// is then about turning to face the right direction, which is arbitrary in
	// 3d with no minimap, and with a minimap the game would be about staring at
	// the minimap. Sound cues, like in Serious Sam, would work, but not well
	// suited to mobile without headphones.
	// So instead, we orbit the player, not necessarily stably
	// This will involve more visual tracking of asteroids that are moving sideways
	// through your field of view, which is the good stuff.
	void MoveTowards (Vector3 dir, float dist) {
		GetComponent<Rigidbody>().velocity = dir * approachSpeedAtBaseDistance * dist / baseDistance;
	}


	void OrbitAround (Transform tgt) {
//		transform.SetParent( tgt );
		orbitCentre = tgt.position;
		secsPerOrbit = Random.Range( minSecsPerOrbit, maxSecsPerOrbit );
		isOrbiting = true;

	}

	void Update () {
		if (isOrbiting) {
			Vector3 fwd = (orbitCentre - transform.position);
			float r = fwd.magnitude;
			float circumferance = Mathf.PI * r * 2.0f;
			float v = circumferance / secsPerOrbit;
			transform.RotateAround( orbitCentre, Vector3.up, v * Time.deltaTime );
			MoveTowards( fwd.normalized, r );
		}
	}

}
