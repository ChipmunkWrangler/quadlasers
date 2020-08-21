using UnityEngine;

public class DestroyByContact : MonoBehaviour {
	public GameObject explosion;
	private GameObject controller;

	private void SetController (GameObject _controller) {
		controller = _controller;
	}

	private void OnHit () {
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