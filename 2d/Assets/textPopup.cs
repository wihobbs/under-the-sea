using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textPopup : MonoBehaviour
{
    Text text;
    float time;
    public float durationBeforeFade = 0.5f;
    public float duration = 2f;
    public float fadeSpeed = 0.75f;
    public float MoveUpSpeed = 0.1f;
    Image[] imageArray;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        imageArray = GetComponentsInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0f, MoveUpSpeed * Time.deltaTime, 0f);
        time += Time.deltaTime;
        if (time > durationBeforeFade){
            text.color -= new Color(0f, 0f, 0f, fadeSpeed * (Time.deltaTime));
            foreach (Image i in imageArray){
                i.color -= new Color(0f, 0f, 0f, fadeSpeed * (Time.deltaTime));
            }
        }

        if (time > duration){
            Destroy(gameObject);
        }
    }
}
