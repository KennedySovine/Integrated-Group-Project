using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{

    public static gameManager Instance;

    public int completedScenes;

    private GameObject pauseMenu;

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

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.Find("PauseMenu");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 7)
        {
            pauseMenu.SetActive(!pauseMenu.activeSelf);
        }
    }

    public void loadNextScene()
    {
        SceneManager.LoadScene(sceneBuildIndex: SceneManager.GetActiveScene().buildIndex + 1); // Gets next build index in the list

    }

    public void loadSelectedScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneBuildIndex: sceneIndex); // Loads the scene with the index passed in
    }

    public void goBack(GameObject menu){
        optionsMenu.SetActive(false);
        if (SceneManager.GetActiveScene().buildIndex != 7)
        {
            GameObject.Find("PauseMenu").SetActive(true);
        }
        else{
            menu.SetActive(true);
        }
    }

}
