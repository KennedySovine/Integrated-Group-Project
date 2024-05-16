using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TW_MenuManager : MonoBehaviour
{
    public int completedScenes = 0 ;

    public GameObject[] levels = new GameObject[7];



    void Start()
    {
        if (!PlayerPrefs.HasKey("completedScenes"))
        {
            PlayerPrefs.SetInt("completedScenes", 0);
        }

        else{
            completedScenes = PlayerPrefs.GetInt("completedScenes");
            Debug.Log(completedScenes);
        }

        DisableLevels();

    }

    void OnEnable()
    {
        Time.timeScale = 1;
    }

    void Update()
    {

    }
    
    public void loadSelectedScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex: sceneIndex); // Loads the scene with the index passed in
    }

    private void DisableLevels()
    {
        for (int i = 0; i < 6-completedScenes; i++)
        {
            Button button = levels[i].GetComponent<Button>();
            if (button != null)
            {
                button.interactable = false;
            }
        }
    
    }
}
