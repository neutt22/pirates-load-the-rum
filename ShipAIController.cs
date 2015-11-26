using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShipAIController : MonoBehaviour {
    
    private Rigidbody2D rb2d;
    private const float KNOCK_BACK_FORCE = 1.5f;

    public CannonSpawnPoint[] cannonSpawnPoints;
    public GameObject cannonBallPrefab;

	void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        StartCoroutine(Shoot());
	}

    void Update()
    {
        for(int m = 0; m < cannonSpawnPoints.Length; m++)
        {
            CannonSpawnPoint spawnPoint = cannonSpawnPoints[m];
            Debug.DrawLine(spawnPoint.startPoint.position, spawnPoint.endPoint.position);
        }
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

    private IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            
            for (int m = 0; m < cannonSpawnPoints.Length; m++)
            {
                CannonSpawnPoint spawnPoint = cannonSpawnPoints[m];
                GameObject rb2d = (GameObject) Instantiate(cannonBallPrefab, spawnPoint.transform.position, spawnPoint.transform.rotation) as GameObject;


                rb2d.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, 0.6f, 0) * Time.fixedDeltaTime);
            }

        }
    }

}
