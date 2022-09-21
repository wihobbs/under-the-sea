using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float speed = 1.5f;
    // Might be good to have varying speeds based on the sprite
    public float timeDestroy = 50.0f;
    public float destroyPosition = -10;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * -1 * Time.deltaTime);

        if (transform.position.x <= destroyPosition){
             Destroy(gameObject);
        }
    }
}
