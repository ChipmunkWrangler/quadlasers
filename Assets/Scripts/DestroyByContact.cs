using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	private GameObject controller;

	void SetController (GameObject _controller) {
		controller = _controller;
	}

	void OnHit () {
		if (explosion != null) {
			GameObject o = Instantiate( explosion, transform.position, transform.rotation );
			AudioSource audioSource = o.GetComponent<AudioSource>();
			if (audioSource != null) {
				audioSource.Play();
			}
		}
			
		controller.SendMessage( "ObjectDestroyed", gameObject );
		Destroy( gameObject );
	}
}