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
    int maxHealth = 10;

    public AudioClip treasureSound;
    public AudioClip zapSound;
    public AudioClip healthSound;
    public AudioClip deathSound;
    public AudioClip slowSound;
    AudioSource source;

    public float verticalSensitivity = 0.2f;
    public float rotateIntensity = 10f;

    public float score = 0;
    public float scoreIncreaseRate = 10;
    public SpawnEnemy singleton;
    public GameObject followCanvas;
    public GameObject deathCanvas;
    [HideInInspector]
    public bool alive;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
        singleton = GameObject.Find("Singleton").GetComponent<SpawnEnemy>();

        health = 10;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        score += alive ? Time.deltaTime * singleton.progressionRate * scoreIncreaseRate : 0;

        //Add Force up and down
        if (alive)
            rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * verticalSensitivity), ForceMode2D.Impulse);
        
        anim.SetBool("swimming", Input.GetAxis("Vertical") != 0);
        
        //Rotate fish up and down depending on vertical velocity
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotateIntensity);

        health = health < 0 ? 0 : health;

        if (health <= 0 && alive) {
            singleton.progressionRate = 0;
            singleton.progressionRateAccel = 0;
            deathCanvas.SetActive(true);
            Camera.main.gameObject.GetComponent<AudioSource>().clip = null;
            source.PlayOneShot(deathSound, 0.7f); 
            alive = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //if (!collision.gameObject.GetComponent<Obstacle>().hit){
            switch(collision.gameObject.tag) {
                case "treasure":
                    score += 500;
                    source.PlayOneShot(treasureSound, 1f);
                    singleton.progressionRate *= 1.1f;
                    Destroy(collision.gameObject);
                    Debug.Log("treasure!");
                    break;
                case "greenJellyfish":
                    health = (health == maxHealth) ? maxHealth : health + 1;
                    source.PlayOneShot(healthSound, 1f);
                    Destroy(collision.gameObject);
                    Debug.Log("health!");
                    break;
            }
            if (collision.gameObject.GetComponent<Obstacle>().popup != null){
                Instantiate(collision.gameObject.GetComponent<Obstacle>().popup, followCanvas.transform);
            }
        //}
        
    }

    void OnCollisionEnter2D(Collision2D collision){
        //if (!collision.gameObject.GetComponent<Obstacle>().hit){
            switch(collision.gameObject.tag) {
                case "bigShark":
                    score -= 1000;
                    health -= 2;
                    source.PlayOneShot(zapSound, 1f);
                    Debug.Log("damaged!");
                    anim.SetBool("damaged", true);
                    break;
                case "starfish":
                    score -= 10;
                    source.PlayOneShot(slowSound, 1f);
                    singleton.progressionRate *= 0.75f;
                    break;
                case "pinkJellyfish":
                    score -= 500;
                    health -= 1;
                    source.PlayOneShot(zapSound, 1f);
                    singleton.progressionRate *= 0.9f;
                    Debug.Log("zapped!");
                    anim.SetBool("zapped", true);
                    break;
            }
        //}
        if (collision.gameObject.GetComponent<Obstacle>().popup != null){
            Instantiate(collision.gameObject.GetComponent<Obstacle>().popup, followCanvas.transform);
        }
        
    }
    
    void OnCollisionExit2D(Collision2D collision){
        anim.SetBool("zapped", false);
        anim.SetBool("damaged", false);
    }
}
