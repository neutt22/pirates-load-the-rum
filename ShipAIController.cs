using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipAIController : MonoBehaviour {
    
    private Rigidbody2D rb2d;
    private const float KNOCK_BACK_FORCE = 1.5f;
    private ShipAIHealth aiHealth;

	void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        aiHealth = GetComponent<ShipAIHealth>();
	}

    void OnCollisionEnter2D(Collision2D other)
    {
        // If this ship gets hit by other player's damage, then knock it back and damage it.
        if(other.gameObject.tag == "PlayerDamage")
        {
            // Player damage hits the AI ship, apply force for knock back effect
            rb2d.velocity = other.gameObject.transform.up * KNOCK_BACK_FORCE;

            // Take damage from player
            aiHealth.TakeDamage(4);
        }
    }

}
