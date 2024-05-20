using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScrollingText : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] [TextArea] private string[] itemInfo;
    [SerializeField] private GameObject finishButton;
    public float scrollSpeed = 0.1f;

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI itemInfoText;
    public int currentDisplayingTextIndex = 0;
    
    IEnumerator currentCoroutine;
    //private bool lastTextDisplayed = false;

    void Start() {
        currentCoroutine = ScrollText();
        StartCoroutine(currentCoroutine);
    }

    void Update() {
        if (currentDisplayingTextIndex == itemInfo.Length-1 && itemInfoText.text == itemInfo[currentDisplayingTextIndex]) {
            finishButton.SetActive(true);
        }

        else{
        if (Input.GetKeyDown(KeyCode.Space)) {
            // If the text is still displaying, display the whole text
            if (itemInfoText.text != itemInfo[currentDisplayingTextIndex]) {
                StopCoroutine(currentCoroutine);
                itemInfoText.text = itemInfo[currentDisplayingTextIndex];
            } 
            else {
                // If finished displaying all the text, disable the script
                if (currentDisplayingTextIndex >= itemInfo.Length - 1) {
                    gameObject.GetComponent<ScrollingText>().enabled = false;
                } 
                else {
                    StopCoroutine(currentCoroutine);
                    currentDisplayingTextIndex++;
                    itemInfoText.text = "";
                    currentCoroutine = ScrollText();
                    StartCoroutine(currentCoroutine);
                }
            }
        }
        }
    }

    IEnumerator ScrollText() {
        for (int i = 0; i <= itemInfo[currentDisplayingTextIndex].Length; i++) {
            itemInfoText.text = itemInfo[currentDisplayingTextIndex].Substring(0, i);
            yield return new WaitForSeconds(scrollSpeed);
        }
    }

}