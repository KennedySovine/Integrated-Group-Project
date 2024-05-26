using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class VolumeConvert : MonoBehaviour
{
    public TextMeshProUGUI volumeText;
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
        float normalizedVolume;
        if (gameObject.name == "Master")
        {
            normalizedVolume = ((volume - (-80)) / (5 - (-80))) * (100 - 0) + 0;
            volumeText.text = normalizedVolume.ToString("0");
            PlayerPrefs.SetFloat("masterVolume", volume);
        }
        else if (gameObject.name == "Music")
        {
            normalizedVolume = ((volume - (-80)) / (5 - (-80))) * (100 - 0) + 0;
            volumeText.text = normalizedVolume.ToString("0");
            PlayerPrefs.SetFloat("musicVolume", volume);
        }
        else if (gameObject.name == "SFX")
        {
            volumeText.text = volume.ToString("0");
            PlayerPrefs.SetFloat("sfxVolume", volume);
        }
    }
}
