using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureMove : MonoBehaviour
{
    public float speed = 1.5f;
    // Might be good to have varying speeds based on the sprite
    public float timeDestroy = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Destroy(this.gameObject, timeDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * -1 * Time.deltaTime);
    }
}
