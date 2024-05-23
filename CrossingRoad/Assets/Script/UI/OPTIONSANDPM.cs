using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class OPTIONSANDPM : MonoBehaviour
{
    public static OPTIONSANDPM Instance;

    [Header("Settings")]
    public bool fullscreen;
    public float masterVolume;
    public float musicVolume;
    public float sfxVolume;
    public bool dyslexiaFriendly;

    [Header("UI Elements")]
    [SerializeField] private AudioMixer masterMixer;
    [SerializeField] private GameObject fullscreenToggle;
    [SerializeField] private GameObject dyslexiaFriendlyToggle;
    [SerializeField] private GameObject masterVolumeSlider;
    [SerializeField] private GameObject musicVolumeSlider;
    [SerializeField] private GameObject sfxVolumeSlider;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadSettings();
        SetSettings();
    }

    void Start()
    {

    }

    void Update()
    {
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
        masterVolume = volume;
        masterMixer.SetFloat("masterVol", volume);
    }

    public void MusicVolume(float volume)
    {
        musicVolume = volume;
        masterMixer.SetFloat("musicVol", volume);
    }

    public void SFXVolume(float volume)
    {
        sfxVolume = volume;
        masterMixer.SetFloat("sfxVol", volume);
    }

    public void DyslexiaFriendly(bool isDyslexiaFriendly)
    {
        dyslexiaFriendly = isDyslexiaFriendly;
    }

    public void FullScreen(bool isFullscreen)
    {
        fullscreen = isFullscreen;
    }

    public void SetSettings(){
        LoadSettings();
        //Audio
        masterMixer.SetFloat("masterVol", masterVolume);
        masterMixer.SetFloat("musicVol", musicVolume);
        masterMixer.SetFloat("sfxVol", sfxVolume);

        //Visuals
        fullscreenToggle.GetComponent<Toggle>().isOn = fullscreen;
        dyslexiaFriendlyToggle.GetComponent<Toggle>().isOn = dyslexiaFriendly;
        masterVolumeSlider.GetComponent<Slider>().value = masterVolume;
        musicVolumeSlider.GetComponent<Slider>().value = musicVolume;
        sfxVolumeSlider.GetComponent<Slider>().value = sfxVolume;
    }

}
