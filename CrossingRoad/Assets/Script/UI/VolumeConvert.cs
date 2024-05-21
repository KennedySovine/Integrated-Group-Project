using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeConvert : MonoBehaviour
{
    public Text volumeText;
    public Slider slider;

    public float volumeAmount;

    private OPTIONSANDPM options;

    void Start()
    {
        options = OPTIONSANDPM.Instance;
        slider = gameObject.GetComponent<Slider>();
    }

    void Update()
    {
        if (slider.value != volumeAmount)
        {
            volumeAmount = slider.value;
            UpdateVolume(slider.value);
        }
    }

    public void UpdateVolume(float volume)
    {
        volumeText.text = (volume * 100).ToString("0");

        if (gameObject.name == "Master")
        {
            options.SetMasterVolume(volume);
        }
        else if (gameObject.name == "Music")
        {
            options.SetMusicVolume(volume);
        }
        else if (gameObject.name == "SFX")
        {
            options.SetSFXVolume(volume);
        }
    }
}