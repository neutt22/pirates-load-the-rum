using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Steer2D;

public class AIManagerScript : MonoBehaviour {

    public Transform[] spawnPoints;
    public GameObject AIShipPrefab;
    public GameObject AIPathsPrefab;

    private GameObject[] AIShips;
    
	void Start () {

        // list of AI ships
        AIShips = new GameObject[spawnPoints.Length];

        // Instantiate AI ships and populate into a list
	    for(int m = 0; m < spawnPoints.Length; m++)
        {
            GameObject gameObject = (GameObject) Instantiate(AIShipPrefab, spawnPoints[m].transform.position, spawnPoints[m].rotation) as GameObject;
            AIShips[m] = gameObject;
        }

        // Instantiate paths prefab
        AIPathsPrefab = Instantiate(AIPathsPrefab);

        // Get all paths gameobject children from paths prefab
        FollowPath[] transforms = AIPathsPrefab.GetComponentsInChildren<FollowPath>();
        List<Vector2[]> followPaths = new List<Vector2[]>();

        // Populate paths into a list
        for(int m = 0; m < transforms.Length; m++)
        {
            Vector2[] followPath = transforms[m].Path;
            followPaths.Add(followPath);
        }
        
        // Update the value of AI ships' Follow Path class
        for(int m = 0; m < AIShips.Length; m++)
        {
            AIShips[m].GetComponent<FollowPath>().Path = followPaths[m];
        }

        // Destroy AIPaths prefab since we got follow paths values
        Destroy(AIPathsPrefab);
	}

}
