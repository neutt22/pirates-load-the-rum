using UnityEngine;
using System.Collections;

public class ShipShooter : MonoBehaviour {

	public GameObject cannonBall;
	public Transform cannonBallSpawn;

	private bool fired = false;


	// For Windows only
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
			fired = true;
	}

	// For Windows only
	void FixedUpdate(){
		if(fired){
			fired = false;
			GameObject rb2d = (GameObject) Instantiate(cannonBall, cannonBallSpawn.transform.position, cannonBallSpawn.rotation) as GameObject;
			rb2d.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0,0.6f,0) * Time.fixedDeltaTime);
		}
	}

	public void FireRight(){
		GameObject rb2d = (GameObject) Instantiate(cannonBall, cannonBallSpawn.transform.position, cannonBallSpawn.rotation) as GameObject;
		rb2d.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0,0.6f,0) * Time.fixedDeltaTime);
	}
}
