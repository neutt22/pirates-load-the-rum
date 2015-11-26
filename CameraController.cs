using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform ship;

    private Vector3 movement;
    private const float Z_AXIS = -10f;

    void Start()
    {
        movement = Vector3.zero;
    }

	void Update () {

        // Lerp the X and Y axis
		float lerpX = Mathf.Lerp(transform.position.x, ship.position.x, 0.01f);
		float lerpY = Mathf.Lerp(transform.position.y, ship.position.y, 0.01f);

        // Update the movement vector
        movement.x = lerpX;
        movement.y = lerpY;
        movement.z = Z_AXIS;

        transform.position = movement;
	}
}
