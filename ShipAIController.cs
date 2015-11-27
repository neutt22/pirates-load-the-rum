using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipAIController : MonoBehaviour {
    
    private Rigidbody2D rb2d;
    private const float KNOCK_BACK_FORCE = 1.5f;

	void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        // If this ship gets hit by other enemy's damage, then don't knock it back.
        if(other.gameObject.tag == "EnemyDamage")
        {
            Destroy(other.gameObject);
            return;
        }

        // Something hits the AI ship, apply force for knock back effect
        rb2d.velocity = other.gameObject.transform.up * KNOCK_BACK_FORCE;
    }

}
