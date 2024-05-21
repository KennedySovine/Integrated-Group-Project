using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OPTIONSANDPM : MonoBehaviour
{
    public static OPTIONSANDPM Instance;

    public bool fullscreen;
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;
    public bool dyslexiaFriendly;

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

    public void SetFullscreen(bool isFullscreen){
        fullscreen = isFullscreen;
        Screen.fullScreen = fullscreen;
    }
    public void SetMasterVolume(float volume){
        masterVolume = volume;
    }
    public void SetMusicVolume(float volume){
        musicVolume = volume;
    }
    public void SetSFXVolume(float volume){
        sfxVolume = volume;
    }
    public void SetDyslexiaFriendly(bool isDyslexiaFriendly){
        dyslexiaFriendly = isDyslexiaFriendly;
    }
}
