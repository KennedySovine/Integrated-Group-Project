using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialShow : MonoBehaviour
{
    [SerializeField] private Camera Light;
    [SerializeField] private ScrollingText scrollingText;
    [SerializeField] private int startTextIndex = 0;
    [SerializeField] private int endTextIndex = 0;
    private Camera mainCamera;

    void Start()
    {
        scrollingText = GameObject.Find("LevelManager").GetComponent<ScrollingText>();
        Light.enabled = false;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (scrollingText.currentDisplayingTextIndex == startTextIndex){
            Light.enabled = true;
            mainCamera.enabled = false;
        }
        else if (scrollingText.currentDisplayingTextIndex == endTextIndex){
            Light.enabled = false;
            mainCamera.enabled = true;
        }
    }
}
