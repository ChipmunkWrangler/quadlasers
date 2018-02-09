using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float minSpeed;
	public float maxSpeed;
	[SerializeField] float approachSpeed;

	Vector3 orbitCentre;
	float speed;
	bool isOrbiting;


	// the problem with moving directly towards the player is that the game
	// is then about turning to face the right direction, which is arbitrary in
	// 3d with no minimap, and with a minimap the game would be about staring at
	// the minimap. Sound cues, like in Serious Sam, would work, but not well
	// suited to mobile without headphones.
	// So instead, we orbit the player, not necessarily stably
	// This will involve more visual tracking of asteroids that are moving sideways
	// through your field of view, which is the good stuff.
	void MoveTowards (Vector3 tgt) {
		Vector3 fwd = (tgt - transform.position).normalized;
		GetComponent<Rigidbody>().velocity = fwd * approachSpeed;
	}


	void OrbitAround (Transform tgt) {
		transform.SetParent( tgt );
		orbitCentre = tgt.position;
		speed = Random.Range( minSpeed, maxSpeed );
		isOrbiting = true;

	}

	void Update () {
		if (isOrbiting) {
			transform.RotateAround( orbitCentre, Vector3.up, speed * Time.deltaTime );
			MoveTowards( orbitCentre );
		}
	}

}
