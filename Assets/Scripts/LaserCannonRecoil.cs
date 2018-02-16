using UnityEngine;
using System.Collections;

public class LaserCannonRecoil : MonoBehaviour {
	public float recoilDuration;
	public float returnDuration;
	public float recoilOffset;
    [SerializeField] Vector3 viewportPos = Vector3.zero;

	private Vector3 originalPos;
	private Vector3 recoilledPos;

	void Start () {
		transform.position = Camera.main.ViewportToWorldPoint( viewportPos );
		originalPos = transform.localPosition;
		recoilledPos = transform.localPosition - Vector3.forward * recoilOffset;
	}

	void FireAt () {
		StopCoroutine( "Recoil" );
		StartCoroutine( "Recoil" ); 
	}

	IEnumerator Recoil () {
		yield return StartCoroutine( MoveToPosition( recoilledPos, recoilDuration, CubicOut ) );
		yield return StartCoroutine( MoveToPosition( originalPos, returnDuration, Vector3.Lerp ) );
	}

	IEnumerator MoveToPosition (Vector3 targetPos, float duration, EaseDelegate getCurrentPosition) {
		float elapsedTime = 0;
		Vector3 startingPos = transform.localPosition;

		while (elapsedTime < duration) {
			transform.localPosition = getCurrentPosition( startingPos, targetPos, (elapsedTime / duration) );
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = targetPos;
	}

	Vector3 QuadraticOut (Vector3 startingPos, Vector3 targetPos, float t) {
		return (startingPos - targetPos) * t * (t - 2) + startingPos;
	}

	Vector3 CubicOut (Vector3 startingPos, Vector3 targetPos, float t) {
		t -= 1;
		return (targetPos - startingPos) * (t * t * t + 1) + startingPos;
	}

	delegate Vector3 EaseDelegate (Vector3 startingPos, Vector3 targetPos, float t);
}


