using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TW_MenuManager : MonoBehaviour
{

    public void PlayLevel()
    {
        SceneManager.LoadSceneAsync("LevelScene");
    }



    public void QuitGame()
    {
        Application.Quit();
    }
        
}
