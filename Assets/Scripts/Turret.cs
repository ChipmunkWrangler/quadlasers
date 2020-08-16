#if !UNITY_EDITOR && (UNITY_IOS || UNITY_ANDROID)
#define ATTITUDE_BASED_ROTATION
#endif
using UnityEngine;


public class Turret : MonoBehaviour {
	public float mouseRotationSpeed;
#if !ATTITUDE_BASED_ROTATION
	private Rigidbody rb;
#endif

	private void Start () {
#if ATTITUDE_BASED_ROTATION
		Input.gyro.enabled = true;
#else
		rb = GetComponent<Rigidbody>();
#endif
	}

#if ATTITUDE_BASED_ROTATION
	private void Update()
	{
			transform.rotation = Input.gyro.attitude;
			transform.Rotate( 0f, 0f, 180f, Space.Self ); // Swap "handedness" of quaternion from gyro.
			transform.Rotate( 90f, 180f, 0f, Space.World ); // Rotate to make sense as a camera pointing out the back of your device.
	}
#else
	private void FixedUpdate ()
	{
		Vector3 rotationVelocity = GetMouseInput();
		rb.AddTorque( transform.right * rotationVelocity.x );	
		rb.AddTorque( transform.up * rotationVelocity.y );
	}
	
	Vector3 GetMouseInput () {
		return new Vector3( -Input.GetAxis( "Mouse Y" ), Input.GetAxis( "Mouse X" ), 0.0f ) * mouseRotationSpeed;
	}
#endif
}