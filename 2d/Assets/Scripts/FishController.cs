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

    public float verticalSensitivity = 0.2f;
    public float rotateIntensity = 10f;

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
        //Add Force up and down
        rb.AddForce(new Vector2(0, Input.GetAxis("Vertical") * verticalSensitivity), ForceMode2D.Impulse);

        
        anim.SetBool("swimming", Input.GetAxis("Vertical") != 0);
        
        //Rotate fish up and down depending on vertical velocity
        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotateIntensity);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            print("you died");
            // Here could call a final screen
        }
    }
}
