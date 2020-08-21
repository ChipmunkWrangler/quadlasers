using System.Collections;
using UnityEngine;

public class LaserCannonRecoil : MonoBehaviour {
	public float recoilDuration;
	public float returnDuration;
	public float recoilOffset;
    [SerializeField] public Vector3 viewportPos = Vector3.zero;

	private Vector3 originalPos;
	private Vector3 recoilledPos;

	private void Start () {
		transform.position = Camera.main.ViewportToWorldPoint( viewportPos );
		originalPos = transform.localPosition;
		recoilledPos = transform.localPosition - Vector3.forward * recoilOffset;
	}

	private void FireAt () {
		StopCoroutine( "Recoil" );
		StartCoroutine( "Recoil" ); 
	}

	private IEnumerator Recoil () {
		yield return StartCoroutine( MoveToPosition( recoilledPos, recoilDuration, CubicOut ) );
		yield return StartCoroutine( MoveToPosition( originalPos, returnDuration, Vector3.Lerp ) );
	}

	private IEnumerator MoveToPosition (Vector3 targetPos, float duration, EaseDelegate getCurrentPosition) {
		float elapsedTime = 0;
		Vector3 startingPos = transform.localPosition;

		while (elapsedTime < duration) {
			transform.localPosition = getCurrentPosition( startingPos, targetPos, (elapsedTime / duration) );
			elapsedTime += Time.deltaTime;
			yield return null;
		}
		transform.localPosition = targetPos;
	}

	private Vector3 QuadraticOut (Vector3 startingPos, Vector3 targetPos, float t) {
		return (startingPos - targetPos) * t * (t - 2) + startingPos;
	}

	private Vector3 CubicOut (Vector3 startingPos, Vector3 targetPos, float t) {
		t -= 1;
		return (targetPos - startingPos) * (t * t * t + 1) + startingPos;
	}

	private delegate Vector3 EaseDelegate (Vector3 startingPos, Vector3 targetPos, float t);
}


