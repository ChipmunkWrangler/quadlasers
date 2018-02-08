using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Assertions;

public class LaserHitTest : MonoBehaviour {
	public float fireRate;
	public float lowerDelay;
	public float maxRange;
	public GameObject[] upperViews;
	public GameObject[] lowerViews;

	private bool isLowerActive;
	private float nextFireTime;

	void Update () {
		if (Input.GetButton("Fire1") && Time.time > nextFireTime)
		{
			Fire (isLowerActive ? lowerViews : upperViews);
			nextFireTime = Time.time + ((isLowerActive) ? fireRate - lowerDelay : lowerDelay);
			isLowerActive = !isLowerActive;
		}
	}

	void Fire (GameObject[] views) {
		Ray ray = new Ray(transform.position, transform.forward); 
		Vector3 endPoint = ray.GetPoint (maxRange);
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, maxRange) && hit.collider != null) {
			hit.collider.gameObject.SendMessage ("OnHit"); 
			endPoint = hit.point;
		}
		AssemblyCSharp.SharedLibrary.InformSubscribers(views, "FireAt", endPoint);
	}
}
