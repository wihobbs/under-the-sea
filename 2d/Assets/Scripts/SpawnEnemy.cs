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
    public GameObject PinkJellyfish;
    public GameObject GreenJellyfish;
    public GameObject Starfish;
    public GameObject BigShark;
    public GameObject Treasure;

    float currSpawnTime;
    // five seconds at varying intervals given that there are multiple types of enemies
    // Start is called before the first frame update
    void Start()
    {
        currSpawnTime = maxSpawnTime;
        Random.InitState(randomSeed);
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
        location.x = -10;
        bottomLocation = -10;
        topLocation = -10;
        location.y = Random.Range(bottomLocation, topLocation);
        // pick a random enemy and a random y-coordinate
        GameObject newObj;
        switch(Random.Range(1, 5)) {
            case 1:
                newObj = Instantiate(PinkJellyfish, location, Quaternion.identity);
                break;
            case 2: 
                newObj = Instantiate(BigShark, location, Quaternion.identity);
                break;
            case 3:
                newObj = Instantiate(Starfish, location, Quaternion.identity);
                break;
            case 4:
                newObj = Instantiate(GreenJellyfish, location, Quaternion.identity);
                break;
            case 5:
                newObj = Instantiate(Treasure, location, Quaternion.identity);
                break;
        }
        
    }
}
