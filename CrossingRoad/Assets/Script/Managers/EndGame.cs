using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    private gameManager GM;
    private LevelManager LM;

    [SerializeField] [TextArea] private string[] itemInfo;
    public float scrollSpeed = 0.1f;
    [SerializeField] private GameObject tutorialPanel;
    [SerializeField] private TextMeshProUGUI itemInfoText;
    public int currentDisplayingTextIndex = 0;

    private bool endedLevel = false;

    IEnumerator currentCoroutine;

    // Start is called before the first frame update
    /*void Start()
    {
        GM = gameManager.Instance;
        LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update(){
        if (endedLevel){
            currentCoroutine = ScrollText();
            StartCoroutine(currentCoroutine);
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
                    GM.loadSelectedScene(0);
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

    private void OnTriggerEnter(Collider other)
    {
        endedLevel = true;
        PlayerPrefs.SetInt("completedScenes", PlayerPrefs.GetInt("completedScenes") + 1);
        tutorialPanel.SetActive(true);
        LM.isMoving = false;
        LM.isCrossing = false;
        LM.lookedLeft = false;
    }
        

    IEnumerator ScrollText() {
        for (int i = 0; i <= itemInfo[currentDisplayingTextIndex].Length; i++) {
            itemInfoText.text = itemInfo[currentDisplayingTextIndex].Substring(0, i);
            yield return new WaitForSeconds(scrollSpeed);
        }
    }*/

    void Start()
    {
        GM = gameManager.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("completedScenes", PlayerPrefs.GetInt("completedScenes") + 1);
        GM.loadSelectedScene(0);
    } 
}
