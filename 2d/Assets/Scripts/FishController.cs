/*
Written by Myopic Games
10/07/22
FishController.cs

This script contains the necessary functions for the fish (Player).
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D col;
    public SpriteRenderer sr;
    public Animator anim;
    // check if the fish is on the ground or not
    public bool grounded = false;
    // amount of health the fish has
    public int health = 10;

    public int maxHealth = 10;

    // when collide with treasure
    public AudioClip treasureSound;
    // when collide with pink jelly
    public AudioClip zapSound;
    // when collide with green jelly
    public AudioClip healthSound;
    AudioSource source;

    public float verticalSensitivity = 0.2f;
    // how much to rotate by
    public float rotateIntensity = 10f;

    public float score = 0;
    public float scoreIncreaseRate = 10;
    private float timer = 0.0f;
    public SpawnEnemy singleton;
    public GameObject deathCanvas;

    public int treasureBonus = 500;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        singleton = GameObject.Find("Singleton").GetComponent<SpawnEnemy>();

        health = 10;
    }

    // Update is called once per frame
    void Update()
    {
        // increase the timer
        timer += Time.deltaTime;
        if (timer > 1.0f) {
            timer = 0.0f;
            score += 1;
            print(score);
        }
        // increase the score
        score += Time.deltaTime * singleton.progressionRate * scoreIncreaseRate;

        //Add Force up and down
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * verticalSensitivity), ForceMode2D.Impulse);

        // set the animations 
        anim.SetBool("swimming", Input.GetAxis("Vertical") != 0);
        
        //Rotate fish up and down depending on vertical velocity
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotateIntensity);

        // no negative health
        health = health < 0 ? 0 : health;

        if (health == 0){
            singleton.progressionRate = 0;
            // fish feints
            deathCanvas.SetActive(true);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<Obstacle>().hit){
            switch(collision.gameObject.tag) {
                case "treasure":
                    // score increases by 500 for treasure
                    score += this.treasureBonus;
                    source.clip = treasureSound;    
                    source.Play();
                    singleton.progressionRate *= 1.1f;
                    Destroy(collision.gameObject);
                    Debug.Log("treasure!");
                    break;
                case "greenJellyfish":
                    // green jelly gives +1 health
                    // can't have more than 10 health
                    health = (health ==this.maxHealth) ? this.maxHealth: health + 1;
                    source.clip = healthSound;    
                    source.Play();
                    Destroy(collision.gameObject);
                    Debug.Log("health!");
                    break;
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        //if (!collision.gameObject.GetComponent<Obstacle>().hit){
            switch(collision.gameObject.tag) {
                case "1000ptEnemy":
                    score -= 1000;
                    health -= 2;
                    source.clip = zapSound;    
                    source.Play();
                    Debug.Log("damaged!");
                    anim.SetBool("damaged", true);
                    break;
                case "100ptEnemy":
                    score -= 100;
                    break;
                case "10ptEnemy":
                    score -= 10;
                    break;
                case "starfish":
                    score -= 10;
                    // move more slowly
                    singleton.progressionRate *= 0.75f;
                    break;
                case "pinkJellyfish":
                    score -= 500;
                    health -= 1;
                    source.clip = zapSound;    
                    source.Play();
                    singleton.progressionRate *= 0.9f;
                    Debug.Log("zapped!");
                    anim.SetBool("zapped", true);
                    break;
            }
        //}
        
    }
    void OnCollisionExit2D(Collision2D collision){
        anim.SetBool("zapped", false);
        anim.SetBool("damaged", false);
    }
}
