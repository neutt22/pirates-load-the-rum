using UnityEngine;
using System.Collections;

public class CannonBallEnemyScript : MonoBehaviour
{

    public ParticleSystem explosionParticle;
    public ParticleSystem waterParticle;
   
    private bool collided = false;

    public void SetLifeTime(float lifeTime)
    {
        // Didn't collide with anything w/n lifetime (range), just destroy it.
        Destroy(gameObject, lifeTime);
    }

    void OnDestroy()
    {
        // Explode water particle because it didn't collide with anything
        if (collided == false)
        {
            ((ParticleSystem)Instantiate(waterParticle, transform.position, transform.rotation) as ParticleSystem).Play();
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Collided with something
        collided = true;

        // If this enemy cannon ball hits other "enemy" tag, then don't blow it.
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
            return;
        }

        // Instantiate an explotion particle object where it collided
        ((ParticleSystem)Instantiate(explosionParticle, transform.position, transform.rotation) as ParticleSystem).Play();

        // Destroy this cannon ball
        Destroy(gameObject);
        
    }

}
