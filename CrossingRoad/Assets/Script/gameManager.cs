using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public static gameManager Instance;

    public int completedScenes;

    [Header("UI Elements")]
    private GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject UI;
    private GameObject eventSystem;
    private OPTIONSANDPM options;

    [SerializeField] private Font dyslexicFont;
    [SerializeField] private Font normalFont;


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
        PlayerPrefs.DeleteAll();
        pauseMenu = GameObject.Find("PauseMenu");
        optionsMenu = GameObject.Find("Options_Panel");
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        UI = null;
        eventSystem = GameObject.Find("EventSystem");
        options = OPTIONSANDPM.Instance;

        options.LoadSettings();
    }

    // Update is called once per frame
    void Update()
    {
        if (UI == null)
        {
            UI = GameObject.Find("UI");
        }

        //Changes between windowed and fullscreen
        options.fullscreen = Screen.fullScreen;
        Debug.Log(options.dyslexiaFriendly);
        if (options.dyslexiaFriendly){
            Text[] texts = GameObject.FindObjectsOfType<Text>();
            foreach (Text text in texts)
            {
                text.font = dyslexicFont;
            }
        }
        else if (!options.dyslexiaFriendly){
            Text[] texts = GameObject.FindObjectsOfType<Text>();
            foreach (Text text in texts)
            {
                text.font = normalFont;
            }
        }
        
        pauseGame();
        
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
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            GameObject.Find("PauseMenu").SetActive(true);
        }
        else{

            menu.SetActive(true);
        }
    }

    public void pauseGame(){
        if(Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().buildIndex != 0)
        {
            eventSystem = GameObject.Find("EventSystem");
            pauseMenu.SetActive(!pauseMenu.activeSelf);
            UI.SetActive(!pauseMenu.activeSelf);

            if (pauseMenu.activeSelf)
            {
                eventSystem.transform.SetParent(GameObject.Find("OPTIONSANDPM").transform);
                Time.timeScale = 0;
            }
            else
            {
                eventSystem.transform.SetParent(GameObject.Find("UI").transform);
                Time.timeScale = 1;
            }
        }
    }

    public void quitGame()
    {
        Application.Quit();
    }

}
