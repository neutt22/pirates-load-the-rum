using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShipAIHealth : MonoBehaviour {

    private int health = 100;

    public Slider healthUI;

    void Start()
    {
        healthUI.value = health;
    }

	public void TakeDamage(int damage)
    {
        if(health > 0)
        {
            health -= damage;

            healthUI.value = health;
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
