using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public Text timeText;
    float time;

    public FishController controller;

    public Image[] hearts;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("PlayerController").GetComponent<FishController>();

    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = ((int)GameObject.Find("PlayerController").GetComponent<FishController>().score).ToString();
        time += Time.deltaTime;
        timeText.text = timeFormat(time);
        
        for (int i = 0; i < hearts.Length; i++){
            hearts[i].fillAmount = Mathf.Clamp(controller.health * 0.5f - i, 0f, 1f);
        }
    }

    string timeFormat(float temp)
    {
        int m = (int)temp / 60 ;
        int s = (int)temp - m * 60;
        int ms = (int)(1000 * (temp - m * 60 - s));
        return string.Format("{0:00}:{1:00}:{2:000}", m, s, ms);
    }
}
