using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {
	public float minSpeed;
	public float maxSpeed;

	void MoveTowards (Vector3 tgt) {
		Vector3 fwd = (tgt - transform.position).normalized;
		GetComponent<Rigidbody>().velocity = fwd * Random.Range( minSpeed, maxSpeed );
	}
}
