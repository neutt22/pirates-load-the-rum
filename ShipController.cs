using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipController : MonoBehaviour {

    private float ROTATE_AMOUNT = 1f; // at full tilt, rotate at 2 degrees per update
    private float TILT_MIN = 0.03f;
    private float TILT_MAX = 0.2f;

    private Rigidbody2D rb2d;
    private const float KNOCK_BACK_FORCE = 1.5f;
    private Vector3 forwardSpeed;

	void Start(){

        rb2d = GetComponent<Rigidbody2D>();

        forwardSpeed = Vector3.up;
	}

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

        //transform.position += forwardSpeed * Time.deltaTime; // <- trouble
        transform.Translate(forwardSpeed * Time.deltaTime);

		float tiltValue = GetTiltValue();
		Vector3 oldAngles = transform.eulerAngles;
        //transform.eulerAngles = new Vector3(oldAngles.x, oldAngles.y, oldAngles.z + (tiltValue * ROTATE_AMOUNT));
        transform.eulerAngles = new Vector3(0, 0, oldAngles.z + (tiltValue * ROTATE_AMOUNT));
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        // Something hits the AI ship, apply force for knock back effect
        rb2d.velocity = other.gameObject.transform.up * KNOCK_BACK_FORCE;
    }
}
