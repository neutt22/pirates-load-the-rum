using UnityEngine;
using System.Collections;

public class CannonBallScript : MonoBehaviour {

	public ParticleSystem particle;

	void Awake () {

		// didn't collide to anything w/n 2 seconds (range), just destroy it.
		Destroy(gameObject, 2f);
	}

	void OnCollisionEnter2D(Collision2D other){

		// Instantiate an explotion particle object where it collided
		((ParticleSystem) Instantiate(particle, transform.position, transform.rotation) as ParticleSystem).Play();
		
		// Destroy this cannon ball
		Destroy(gameObject);
	}
	
	void OnTriggerEnter2D(Collider2D other){

		// Instantiate an explotion particle object where it collided
		((ParticleSystem) Instantiate(particle, transform.position, transform.rotation) as ParticleSystem).Play();

		// Destroy this cannon ball
		Destroy(gameObject);
	}
}
