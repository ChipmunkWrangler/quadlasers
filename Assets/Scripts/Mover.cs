using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float minSpeed;
	public float maxSpeed;
	[SerializeField] float approachSpeedFactor;

	Vector3 orbitCentre;
	Vector3 axis;
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
		GetComponent<Rigidbody>().velocity = fwd * speed * approachSpeedFactor;
	}


	void OrbitAround (Transform tgt) {
		transform.SetParent( tgt );
		orbitCentre = tgt.position;
		speed = Random.Range( minSpeed, maxSpeed );
		axis = GetNormal();
		isOrbiting = true;

	}

	Vector3 GetNormal () {
		// first pick a plane on which our position and our orbital centre lie:
		Vector3 p1 = transform.position;
		Vector3 p2 = orbitCentre;
		Vector3 p3 = Random.onUnitSphere;
		Vector3 side1 = p2 - p1;
		Vector3 side2 = p3 - p1;
		if (side1 == Vector3.zero) {
			side1 = Vector3.forward;
		}
		if (side2 == Vector3.zero) {
			side2 = Vector3.up;
		}
		return Vector3.Cross( side1, side2 );
	}

	void Update () {
		if (isOrbiting) {
			transform.RotateAround( orbitCentre, axis, speed * Time.deltaTime );
			MoveTowards( orbitCentre );
			Debug.Log( (transform.position - orbitCentre).magnitude );
		}
	}

}
