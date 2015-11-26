using UnityEngine;
using System.Collections;

public class ShipAIController : MonoBehaviour {
    
    private Rigidbody2D rb2d;

	public Transform frontStartRay;
	public Transform frontEndRay;

    private const float KNOCK_BACK_FORCE = 1.5f;

	void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        // Something hits the AI ship, apply force for knock back effect
        rb2d.velocity = other.gameObject.transform.up * KNOCK_BACK_FORCE;
    }



}
