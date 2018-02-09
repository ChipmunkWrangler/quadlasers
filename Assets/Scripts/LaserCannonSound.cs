using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCannonSound : MonoBehaviour {
	AudioSource audioSource;

	void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	void FireAt () {
		if (audioSource != null) {
			audioSource.Play();
		}
	}
}
