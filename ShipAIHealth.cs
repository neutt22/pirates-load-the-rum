using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipAIHealth : MonoBehaviour {

    private int health = 100;

    public GameObject aiShooter;
    public ParticleSystem smokeParticle;
    public Slider healthUI;

    void Start()
    {
        healthUI.value = health;
    }

	public void TakeDamage(int damage)
    {
        // Take some damage
        health -= damage;

        if (health > 0)
        {
            // Has more health left, display it.
            healthUI.value = health;
        }
        else
        {
            // No more health, destroy this AI ship.
            healthUI.value = 0;
            aiShooter.SetActive(false);
        }

        if(health <= 30)
        {
            smokeParticle.Play();
        }
    }

    public int Health
    {
        get
        {
            return health;
        }
    }
}
