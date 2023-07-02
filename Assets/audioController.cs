using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audioController : MonoBehaviour
{
    public Slider slider;
    public AudioSource audioSource;

    private void Awake()
    {
        audioSource = GameObject.Find("musicManager").GetComponent<AudioSource>();
    }
    public void OnSliderValueChanged()
    {
        audioSource.volume = slider.value;
    }
}
