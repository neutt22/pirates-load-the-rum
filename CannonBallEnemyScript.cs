using UnityEngine;
using System.Collections;

public class CannonBallEnemyScript : MonoBehaviour
{

    public ParticleSystem explosionParticle;
    public ParticleSystem waterParticle;

    private bool exploded = false;
    private bool collided = false;

    public void SetLifeTime(float lifeTime)
    {
        // didn't collide to anything w/n lifetime (range), just destroy it.
        Destroy(gameObject, lifeTime);
    }

    void OnDestroy()
    {
        if (collided == false)
        {
            ((ParticleSystem)Instantiate(waterParticle, transform.position, transform.rotation) as ParticleSystem).Play();
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        collided = true;

        // If this enemy cannon ball hits other "enemy" tag, then don't blow it.
        if (other.gameObject.tag == "Enemy")
        {
            exploded = false;
            Destroy(this.gameObject);
            return;
        }

        // This cannon ball gameobject hits a player, explode it.
        exploded = true;

        // Instantiate an explotion particle object where it collided
        ((ParticleSystem)Instantiate(explosionParticle, transform.position, transform.rotation) as ParticleSystem).Play();

        // Destroy this cannon ball
        Destroy(gameObject);
    }

    // Prolly will never be triggered due to isTrigger is false
    void OnTriggerEnter2D(Collider2D other)
    {

        // Instantiate an explotion particle object where it collided
        ((ParticleSystem)Instantiate(explosionParticle, transform.position, transform.rotation) as ParticleSystem).Play();

        // Destroy this cannon ball
        Destroy(gameObject);
    }
}
