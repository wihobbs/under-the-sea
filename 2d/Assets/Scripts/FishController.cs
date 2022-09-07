using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D col;
    public SpriteRenderer sr;
    public bool grounded = false;

    public float verticalSensitivity = 0.2f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //grounded = col.OnCollisionEnter2D();
        if (Input.GetKey("up"))
        {
            rb.AddForce(Vector2.up * verticalSensitivity, ForceMode2D.Impulse);
        }
        if (Input.GetKey("down"))
        {
            rb.AddForce(Vector2.down * verticalSensitivity, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            print("you died");
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
        sr.color = new Color(1, 0.3f, 0.3f);
    }
}
