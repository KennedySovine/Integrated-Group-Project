using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeConvert : MonoBehaviour
{
    public Text volumeText;

    // Update is called once per frame
    public void UpdateVolume(float volume, string Type)
    {
        volumeText.text = (volume * 100).ToString("0");
        if (Type == "Master")
        {
            OPTIONSANDPM.Instance.masterVolume = volume;
        }
        else if (Type == "Music")
        {
            OPTIONSANDPM.Instance.musicVolume = volume;
        }
        else if (Type == "SFX")
        {
            OPTIONSANDPM.Instance.sfxVolume = volume;
        }
    }
}
