using System.Collections;
using UnityEngine;

public class LaserShowBeam : MonoBehaviour {
	public float fireDuration;

	private LineRenderer line;

	private void Start () {
		line = gameObject.GetComponent<LineRenderer> ();
	}

	private void FireAt(Vector3 endpoint) {
		StopCoroutine ("ShowBeam");
		StartCoroutine ("ShowBeam", endpoint);
	}

	private IEnumerator	ShowBeam (Vector3 endPoint) {
		line.enabled = true;
		line.SetPosition (1, transform.InverseTransformPoint (endPoint));
		float endTime = Time.time + fireDuration;
		while (Time.time < endTime) {
			line.material.mainTextureOffset = new Vector2 (0, Time.time);
			yield return null;
		}
//		yield return new WaitForSeconds (fireDuration);
		line.enabled = false;
	}
}
