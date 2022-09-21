using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public int randomSeed = 100;
    public float minSpawnTime = 0.1f;
    public float maxSpawnTime = 1.5f;

    public float topLocation;
    public float bottomLocation;
    public GameObject[] SpawnableObjects;


    float currSpawnTime;
    // five seconds at varying intervals given that there are multiple types of enemies
    // Start is called before the first frame update
    void Start()
    {
        currSpawnTime = maxSpawnTime;
        //Random.InitState(randomSeed);
    }

    // Update is called once per frame
    void Update()
    {
        if(currSpawnTime >= 0.0f) {
            currSpawnTime -= Time.deltaTime;
            return;
        }
        currSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
        Vector3 location = Vector3.zero;
        location.x = 10;
        location.y = Random.Range(bottomLocation, topLocation);
        // pick a random enemy and a random y-coordinate
        //GameObject newObj;
        Instantiate(SpawnableObjects[Random.Range(0, 4)], new Vector2(10, Random.Range(bottomLocation, topLocation)), Quaternion.identity);
        
    }
}
