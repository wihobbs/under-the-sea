/*
Written by Myopic Games
10/07/22
Obstacle.cs

This script contains the necessary functions for Obstacles.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 1.5f;
    public bool randomSpeed = false;
    public Vector2 speedRange = new Vector2(1f, 2f);
    public float spawnProbability = 1;
    // Might be good to have varying speeds based on the sprite
    public float destroyPosition = -10;
    SpawnEnemy singleton;
    public bool loop = false;
    public bool hit = false;
    public bool randomRotate = true;
    public float rotateSpeedMax = 0;
    float rotateSpeed = 0;
    public GameObject popup;


    // Start is called before the first frame update
    void Start()
    {
        singleton = GameObject.Find("Singleton").GetComponent<SpawnEnemy>();
        Random.InitState((int)Time.time + (int)(transform.position.y * 100 + transform.position.x * 1000));
        if (randomSpeed)
            speed = Random.Range(speedRange.x, speedRange.y);
        rotateSpeed = Random.Range(-rotateSpeedMax, rotateSpeedMax);
        if (Random.Range(0f,1f) < (1 - spawnProbability)){
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // move the obstacle
        transform.position -= new Vector3(speed * singleton.progressionRate * Time.deltaTime, 0, 0);

        if (randomRotate){
            transform.eulerAngles += new Vector3(0f, 0f, rotateSpeed * Time.deltaTime);
        }

        if (transform.position.x <= destroyPosition){
            if (!loop){
                Destroy(gameObject);
            }
            else{
                transform.position += new Vector3(20, 0, 0);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        hit = true;
    }
}
