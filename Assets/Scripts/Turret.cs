#if UNITY_IOS || UNITY_ANDROID
#define COMPASS_ROTATION
#endif

using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;


public class Turret : MonoBehaviour {
	//	public GameObject shot;
	//	public Transform shotSpawn;
	// COMPASS_ROTATION
	public float MAX_ACCEPTABLE_HEADING_INACCURACY;
	public GameObject[] subscribers;
	public Text debugText_accuracy;
	public Text debugText_heading;
	// MOUSE ROTATION
	public float speed;
	#if COMPASS_ROTATION
	private bool wasCalibrated;
	


#else
	private Rigidbody rb;
	#endif

	void Start () {
		#if COMPASS_ROTATION
		Input.compass.enabled = true;
		wasCalibrated = true;
		print( "Compass" );
		#else
		rb = GetComponent<Rigidbody>();
		#endif
	}

	void FixedUpdate () {
#if COMPASS_ROTATION
		transform.rotation = GetCompassRotation();
#else
		Vector3 rotationVelocity = GetMouseInput();
//		rb.AddTorque( transform.right * rotationVelocity.x );	
		rb.AddTorque( transform.up * rotationVelocity.y );
#endif
	}

	#if COMPASS_ROTATION
	Quaternion GetCompassRotation () {
		debugText_accuracy.text = Input.compass.headingAccuracy.ToString();
		debugText_heading.text = Input.compass.magneticHeading.ToString();
		if (IsCompassCalibrated()) {
			SetCalibratedStatus( true );
			return Quaternion.Euler( 0, Input.compass.magneticHeading, 0 );
		} else {
			SetCalibratedStatus( false );
			return transform.rotation;
		}
	}

	bool IsCompassCalibrated () {
		return Input.compass.headingAccuracy >= 0 && Input.compass.headingAccuracy < MAX_ACCEPTABLE_HEADING_INACCURACY;
	}

	void SetCalibratedStatus (bool isCalibrated) {
		if (isCalibrated != wasCalibrated) {
			AssemblyCSharp.SharedLibrary.InformSubscribers( subscribers, "CompassCalibrated", isCalibrated );
			wasCalibrated = isCalibrated;
		}

	}

	


#else
	Vector3 GetMouseInput () {
		return new Vector3( -Input.GetAxis( "Mouse Y" ), Input.GetAxis( "Mouse X" ), 0.0f ) * speed;
	}
	#endif
}