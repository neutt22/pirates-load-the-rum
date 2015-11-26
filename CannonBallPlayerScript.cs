using UnityEngine;
using System.Collections;

public class CannonBallPlayerScript : MonoBehaviour
{

    public ParticleSystem explosionParticlePrefab;
    public ParticleSystem waterParticlePrefab;

    private bool collided = false;

    void Awake()
    {

        // didn't collide to anything w/n 2 seconds (range), just destroy it.
        Destroy(gameObject, 2f);
    }

    void OnDestroy()
    {
        // If it didn't collided with anything, just blow the water.
        if(collided == false)
        {
            ((ParticleSystem)Instantiate(waterParticlePrefab, transform.position, transform.rotation) as ParticleSystem).Play();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Collided into something
        collided = true;

        // Instantiate an explotion particle object where it collided
        ((ParticleSystem)Instantiate(explosionParticlePrefab, transform.position, transform.rotation) as ParticleSystem).Play();

        //other.gameObject.GetComponent<Rigidbody2D>().AddForce(this.gameObject.transform.forward * 100f);

        // Destroy this cannon ball
        Destroy(gameObject);
    }

    // Prolly will never be triggered due to isTrigger is false
    void OnTriggerEnter2D(Collider2D other)
    {

        // Instantiate an explotion particle object where it collided
        ((ParticleSystem)Instantiate(explosionParticlePrefab, transform.position, transform.rotation) as ParticleSystem).Play();

        // Destroy this cannon ball
        Destroy(gameObject);
    }
}
