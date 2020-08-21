using UnityEngine;

public class LaserCannonSound : MonoBehaviour {
	private AudioSource audioSource;

	private void Start () {
		audioSource = GetComponent<AudioSource>();
	}

	private void FireAt () {
		if (audioSource != null) {
			audioSource.Play();
		}
	}
}
