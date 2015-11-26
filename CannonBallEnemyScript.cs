using UnityEngine;
using System.Collections;

public class CannonBallEnemyScript : MonoBehaviour
{

    public ParticleSystem particle;

    void Awake()
    {
        // didn't collide to anything w/n 2 seconds (range), just destroy it.
        Destroy(gameObject, 2f);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // If this enemy cannon ball hits other "enemy" tag, then don't blow it.
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            return;
        }

        // Instantiate an explotion particle object where it collided
        ((ParticleSystem)Instantiate(particle, transform.position, transform.rotation) as ParticleSystem).Play();

        //other.gameObject.GetComponent<Rigidbody2D>().AddForce(this.gameObject.transform.forward * 100f);

        // Destroy this cannon ball
        Destroy(gameObject);
    }

    // Prolly will never be triggered due to isTrigger is false
    void OnTriggerEnter2D(Collider2D other)
    {

        // Instantiate an explotion particle object where it collided
        ((ParticleSystem)Instantiate(particle, transform.position, transform.rotation) as ParticleSystem).Play();

        // Destroy this cannon ball
        Destroy(gameObject);
    }
}
