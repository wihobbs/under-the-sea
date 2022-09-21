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
        m_Text.text = ((int)time).ToString();
    }
}
