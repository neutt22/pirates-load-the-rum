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

        StartCoroutine(InitShoot());
	}

    void Update()
    {

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

    private IEnumerator InitShoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            
            for (int m = 0; m < cannonSpawnPoints.Length; m++)
            {
                float lifeTime = Random.Range(1f, 2.2f);

                CannonSpawnPoint spawnPoint = cannonSpawnPoints[m];

                StartCoroutine(Shoot(lifeTime, spawnPoint));
            }

        }
    }

    private IEnumerator Shoot(float lifeTime, CannonSpawnPoint cannonSpawnPoint)
    {
        float wait = Random.Range(0f, 0.5f);

        yield return new WaitForSeconds(wait);

        GameObject rb2d = (GameObject)Instantiate(cannonBallPrefab, cannonSpawnPoint.transform.position, cannonSpawnPoint.transform.rotation) as GameObject;
        
        // Shoot!
        rb2d.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, 0.6f, 0) * Time.fixedDeltaTime);

        CannonBallEnemyScript cannonBallEnemy = rb2d.GetComponent<CannonBallEnemyScript>();
        cannonBallEnemy.SetLifeTime(lifeTime);
    }

}
