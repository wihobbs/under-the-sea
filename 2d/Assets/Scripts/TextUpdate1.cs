using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate1 : MonoBehaviour
{
    Text m_Text;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        m_Text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        m_Text.text = timeFormat(time);
    }

    string timeFormat(float temp)
    {
        int m = (int)temp / 60 ;
        int s = (int)temp - m * 60;
        int ms = (int)(1000 * (temp - m * 60 - s));
        return string.Format("{0:00}:{1:00}:{2:000}", m, s, ms);
    }
}
