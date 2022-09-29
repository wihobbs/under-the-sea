using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D col;
    public SpriteRenderer sr;
    public Animator anim;
    public bool grounded = false;
    public int health = 10;

    public AudioClip treasureSound;
    public AudioClip zapSound;
    public AudioClip healthSound;
    AudioSource source;

    public float verticalSensitivity = 0.2f;
    public float rotateIntensity = 10f;

    public float score = 0;
    public float scoreIncreaseRate = 10;
    private float timer = 0.0f;
    public SpawnEnemy singleton;

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
        timer += Time.deltaTime;
        if (timer > 1.0f) {
            timer = 0.0f;
            score += 1;
            print(score);
        }

        score += Time.deltaTime * singleton.progressionRate * scoreIncreaseRate;

        //Add Force up and down
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * verticalSensitivity), ForceMode2D.Impulse);

        
        anim.SetBool("swimming", Input.GetAxis("Vertical") != 0);
        
        //Rotate fish up and down depending on vertical velocity
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotateIntensity);

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.GetComponent<Obstacle>().hit){
            switch(collision.gameObject.tag) {
                case "treasure":
                    score += 500;
                    source.clip = treasureSound;    
                    source.Play();
                    singleton.progressionRate *= 1.1f;
                    Destroy(collision.gameObject);
                    Debug.Log("treasure!");
                    break;
                case "greenJellyfish":
                    health = (health == 10) ? 10 : health + 1;
                    source.clip = healthSound;    
                    source.Play();
                    Destroy(collision.gameObject);
                    Debug.Log("health!");
                    break;
            }
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (!collision.gameObject.GetComponent<Obstacle>().hit){
            switch(collision.gameObject.tag) {
                case "1000ptEnemy":
                    score -= 1000;
                    health -= 2;
                    break;
                case "100ptEnemy":
                    score -= 100;
                    break;
                case "10ptEnemy":
                    score -= 10;
                    break;
                case "pinkJellyfish":
                    score -= 500;
                    health -= 1;
                    source.clip = zapSound;    
                    source.Play();
                    singleton.progressionRate *= 0.75f;
                    Debug.Log("zapped!");
                    break;
            }
        }
        
    }
}
