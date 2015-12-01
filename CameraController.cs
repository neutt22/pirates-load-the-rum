using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public Transform ship;

    private Vector3 movement;
    private const float Z_AXIS = -10f;

    private Vector3 originPosition;
    private float shakeIntensity;
    private float shakeDecary;

    public const float SHAKE_INTESITY_VALUE = 0.1f;

    void Start()
    {
        movement = Vector3.zero;

        shakeIntensity = 0;
        shakeDecary = 0.003f;

        originPosition = transform.position;
    }

    public float ShakeIntensity
    {
        get
        {
            return shakeIntensity;
        }
        set
        {
            originPosition = transform.position;
            shakeIntensity = value;
        }
    }

    void Update()
    {
        // Shake
        if (shakeIntensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * shakeIntensity;
            shakeIntensity -= shakeDecary;
        }
        else
        {
            // Follow the player ship
            // Lerp the X and Y axis
            float lerpX = Mathf.Lerp(transform.position.x, ship.position.x, 0.015f);
            float lerpY = Mathf.Lerp(transform.position.y, ship.position.y, 0.015f);

            // Update the movement vector
            movement.x = lerpX;
            movement.y = lerpY;
            movement.z = Z_AXIS;

            transform.position = movement;
        }
    }
}
