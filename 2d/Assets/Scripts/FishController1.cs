using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController1 : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D col;
    public SpriteRenderer sr;
    public bool grounded = false;
    
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
        if (Input.GetKey("up") && grounded)
        {
            rb.AddForce(Vector2.up * 0.5f, ForceMode2D.Impulse);
        }

        if (Input.GetKey("right"))
        {
            rb.AddTorque(-5);
        }
        else if (Input.GetKey("left"))
        {
            rb.AddTorque(5);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
        if (collision.gameObject.tag == "Wall")
        {
            sr.color = new Color(0.3f, 1, 0.3f);
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        grounded = false;
        sr.color = new Color(1, 0.3f, 0.3f);
    }
}
