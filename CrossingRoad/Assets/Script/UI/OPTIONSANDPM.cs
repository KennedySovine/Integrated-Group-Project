using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class OPTIONSANDPM : MonoBehaviour
{
    public static OPTIONSANDPM Instance;

    public bool fullscreen;
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;
    public bool dyslexiaFriendly;

    [SerializeField] private AudioMixer masterMixer;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void LoadSettings(){
        fullscreen = PlayerPrefs.GetInt("fullscreen") == 1;
        masterVolume = PlayerPrefs.GetFloat("masterVolume");
        musicVolume = PlayerPrefs.GetFloat("musicVolume");
        sfxVolume = PlayerPrefs.GetFloat("sfxVolume");
        dyslexiaFriendly = PlayerPrefs.GetInt("dyslexiaFriendly") == 1;
    }

    public void SaveSettings(){
        PlayerPrefs.SetInt("fullscreen", fullscreen ? 1 : 0);
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume);
        PlayerPrefs.SetInt("dyslexiaFriendly", dyslexiaFriendly ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void MasterVolume(float volume)
    {
        PlayerPrefs.SetFloat("masterVolume", volume);
        masterMixer.SetFloat("masterVol", volume);
    }

    public void MusicVolume(float volume)
    {
        PlayerPrefs.SetFloat("musicVolume", volume);
        masterMixer.SetFloat("musicVol", volume);
    }
}
