using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform ship;

	// Follow the player's ship smoothly
	void Update () {

		float lerpX = Mathf.Lerp(transform.position.x, ship.position.x, 0.01f);
		float lerpY = Mathf.Lerp(transform.position.y, ship.position.y, 0.01f);

		Vector3 movement = new Vector3(lerpX, lerpY, -10f);

		transform.position = movement;
	}
}
