using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 1.5f;
    // Might be good to have varying speeds based on the sprite
    public float timeDestroy = 50.0f;
    public float destroyPosition = -10;
    public SpawnEnemy singleton;
    public bool loop = false;
    public bool hit = false;
    public float spawnProbability = 1;


    // Start is called before the first frame update
    void Start()
    {
        singleton = GameObject.Find("Singleton").GetComponent<SpawnEnemy>();
        Random.InitState((int)Time.time);
        if (Random.Range(0f,1f) < (1 - spawnProbability)){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * singleton.progressionRate * -1 * Time.deltaTime);

        if (transform.position.x <= destroyPosition){
            if (!loop){
                Destroy(gameObject);
            }
            else{
                transform.position += new Vector3(20, 0, 0);
            }
        }
    }
}
