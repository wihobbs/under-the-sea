/*
Written by Myopic Games
10/07/22
EnemyScripts.cs

This script includes the generally necessary functions for enemies.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // speed of enemys
    public float speed = 7.5f;
    // Might be good to have varying speeds based on the sprite

    // time until enemies are destroyed
    public float timeDestroy = 50.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(this.gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        // move the enemy to the left
        transform.Translate(Vector3.right * speed * -1 * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == "player") {
            // call to quit the game
            
        }
    }
}
