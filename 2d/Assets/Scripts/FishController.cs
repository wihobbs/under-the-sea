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

    public AudioClip treasureSound;
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
        switch(collision.gameObject.tag) {
            case "Wall":
                print("you died");
                break;
            case "1000ptEnemy":
                score -= 1000;
                break;
            case "100ptEnemy":
                score -= 100;
                break;
            case "10ptEnemy":
                score -= 10;
                break;
            case "treasure":
                score += 100;
                source.clip = treasureSound;
                source.Play();
                Destroy(collision.gameObject);
                Debug.Log("treasure!");
                break;
        }
    }
}
