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

    public float progressionRate;
    public float progressionRateAccel = 0.05f;
    public SpawnEnemy singleton;



    float currSpawnTime;
    // five seconds at varying intervals given that there are multiple types of enemies
    // Start is called before the first frame update
    void Start()
    {
        currSpawnTime = maxSpawnTime;
        progressionRate = 1;
        //Random.InitState(randomSeed);
        singleton = GameObject.Find("Singleton").GetComponent<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        progressionRate += Time.deltaTime * progressionRateAccel;
        if(currSpawnTime >= 0.0f) {
            currSpawnTime -= Time.deltaTime;
            return;
        }
        currSpawnTime = Random.Range(minSpawnTime / singleton.progressionRate, maxSpawnTime / singleton.progressionRate);
        Vector3 location = Vector3.zero;
        location.x = 10;
        location.y = Random.Range(bottomLocation, topLocation);
        // pick a random enemy and a random y-coordinate
        //GameObject newObj;
        Instantiate(SpawnableObjects[Random.Range(0, SpawnableObjects.Length)], new Vector2(10, Random.Range(bottomLocation, topLocation)), Quaternion.identity);
        
    }
}
