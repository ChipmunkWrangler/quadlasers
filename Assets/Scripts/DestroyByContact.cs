using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyByContact : MonoBehaviour
{
	public GameObject explosion;
	public int scoreValue;
	private GameObject controller;

	void SetController(GameObject _controller) {
		controller = _controller;
	}

	void OnHit ()
	{
		if (explosion != null)
		{
			Instantiate(explosion, transform.position, transform.rotation);
		}

		controller.SendMessage("ObjectDestroyed", gameObject);
		Destroy (gameObject);
	}
}