/*
Written by Myopic Games
10/07/22
SpawnEnemy.cs

This script contains the necessary functions for the spawning an enemy.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    // random seeds
    public int randomSeed = 100;
    public float randomSeed2 = 100;
    // locations
    public float location = 100;
    // timing
    public float minSpawnTime = 0.1f;
    public float maxSpawnTime = 1.5f;

    public float topLocation;
    public float bottomLocation;
    public GameObject[] SpawnableObjects;

    public float progressionRate;
    public float progressionRateAccel = 0.05f;
    SpawnEnemy singleton;
    public bool spawnEnemies = true;



    public float currSpawnTime;
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

        randomSeed = (int)currSpawnTime * 100;

        //Random.seed = randomSeed;

        location = Random.Range(bottomLocation, topLocation) + currSpawnTime * 2.5f;

        if(currSpawnTime >= 0.0f) {
            currSpawnTime -= Time.deltaTime;
            return;
        }
        currSpawnTime = Random.Range(minSpawnTime / Mathf.Pow(singleton.progressionRate, 2f), maxSpawnTime / Mathf.Pow(singleton.progressionRate, 2f));
        // pick a random enemy and a random y-coordinate
        //GameObject newObj;
        //Random.seed = (int)Random.Range(0, (int)Time.time);
 
        //Debug.Log("location: " + location);
        if (spawnEnemies)
            Instantiate(SpawnableObjects[Random.Range(0, SpawnableObjects.Length)], new Vector2(10, location), Quaternion.identity);
    }
}
