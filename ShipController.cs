using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

	public GameObject waterWaveParticle;

	private WaitForSeconds waterWaveOff;
	private WaitForSeconds waterWaveOn;
	private Vector3 speed;
	private Vector3 forwardSpeed;

	void Start(){
		waterWaveOff = new WaitForSeconds(2);
		waterWaveOn = new WaitForSeconds(0);

		speed = Vector3.one;
		forwardSpeed = new Vector3(0, 1f, 0);
	}


	private float ROTATE_AMOUNT = 0.5f; // at full tilt, rotate at 2 degrees per update
	private float TILT_MIN = 0.05f;
	private float TILT_MAX = 0.2f;

	private float GetTiltValue(){
		// Work out magnitude of tilt
		float tilt = Mathf.Abs(Input.acceleration.x);

		// If not really tilted don't change anything
		if (tilt < TILT_MIN) {
			return 0;
		}
		float tiltScale = (tilt - TILT_MIN) / (TILT_MAX - TILT_MIN);
		
		// Change scale to be negative if accel was negative
		if (Input.acceleration.x < 0) {
			return tiltScale;
		}else{
			return -tiltScale;
		}
	}

	void Update () {


		/*
		if(Input.GetKey(KeyCode.W))
			transform.Translate(Vector3.up * Time.deltaTime);
		*/
		if(Input.GetKey(KeyCode.A))
			transform.Rotate(Vector3.forward + new Vector3(0,0,1f) * Time.deltaTime);

		if(Input.GetKey(KeyCode.D))
			transform.Rotate(-Vector3.forward + new Vector3(0,0,1f) * Time.deltaTime);


		transform.Translate(forwardSpeed * Time.deltaTime);

		float tiltValue = GetTiltValue();
		Vector3 oldAngles = this.transform.eulerAngles;
		this.transform.eulerAngles = new Vector3(oldAngles.x, oldAngles.y, oldAngles.z + (tiltValue * ROTATE_AMOUNT));
	}

	public Text text;

	private IEnumerator CheckWaterWave(bool enabled, WaitForSeconds wait){
		yield return wait;
		waterWaveParticle.SetActive(enabled);
	}
}
