using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolumeSlider : MonoBehaviour
{
    public AudioMixer mixer;
    public string mixerGroup;
    public void SetLevel(float sliderValue)
    {
        mixer.SetFloat(mixerGroup, sliderValue == 0 ? -80 : Mathf.Log10(sliderValue) * 20);
    }
}
