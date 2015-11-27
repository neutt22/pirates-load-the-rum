using UnityEngine;
using System.Collections;

public class ShipAIShooter : MonoBehaviour {

    public CannonSpawnPoint[] cannonSpawnPoints;
    public GameObject cannonBallPrefab;

    void OnTriggerEnter2D(Collider2D other)
    {
        // A player is inside an AI shooting zone, shoot it (depends on spawn points)
        if(other.gameObject.tag == "Player")
        {
            for(int m = 0; m < cannonSpawnPoints.Length; m++)
            {
                CannonSpawnPoint cannonSpawnPoint = cannonSpawnPoints[m];

                float lifeTime = Random.Range(1f, 2.2f);

                StartCoroutine(Shoot(lifeTime, cannonSpawnPoint));
            }
        }
    }

    private IEnumerator Shoot(float lifeTime, CannonSpawnPoint cannonSpawnPoint)
    {
        // Favorite effect ;)
        float wait = Random.Range(0f, 0.5f);
        yield return new WaitForSeconds(wait);

        // Make an AI cannon ball
        GameObject rb2d = (GameObject)Instantiate(cannonBallPrefab, cannonSpawnPoint.transform.position, cannonSpawnPoint.transform.rotation) as GameObject;

        // Shoot!
        rb2d.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector3(0, 0.6f, 0) * Time.fixedDeltaTime);

        // Lifetime of the cannon ball before destroying
        CannonBallEnemyScript cannonBallEnemy = rb2d.GetComponent<CannonBallEnemyScript>();
        cannonBallEnemy.SetLifeTime(lifeTime);
    }
}
