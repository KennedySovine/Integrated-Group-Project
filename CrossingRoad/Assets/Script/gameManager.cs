using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class gameManager : MonoBehaviour
{

    public static gameManager Instance;

    public int completedScenes;

    [Header("UI Elements")]
    [SerializeField] private GameObject pauseMenu;
    public GameObject optionsMenu;
    public GameObject UI;
    private GameObject eventSystem;
    private OPTIONSANDPM options;

    [SerializeField] private Font dyslexicFont;
    [SerializeField] private Font normalFont;
    [SerializeField] public TMP_FontAsset dyslexicFontAsset;
    [SerializeField] public TMP_FontAsset normalFontAsset;


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
        optionsMenu = GameObject.Find("Options_Panel");
        optionsMenu.SetActive(false);
        pauseMenu.SetActive(false);
        UI = null;
        eventSystem = GameObject.Find("EventSystem");
        options = OPTIONSANDPM.Instance;
        GetComponent<AudioSource>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (UI == null)
        {
            UI = GameObject.Find("UI");
        }
        
        setFont();
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
            pauseMenu.SetActive(true);
        }
        else{

            menu.SetActive(true);
        }
    }

    public void pauseGame(){
        // Pause game when escape key is pressed and not in main menu
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

    public void setFont(){
        if (options.dyslexiaFriendly){
            Text[] texts = GameObject.FindObjectsOfType<Text>();
            foreach (Text text in texts)
            {
                text.font = dyslexicFont;
            }
            TextMeshProUGUI[] texts2 = GameObject.FindObjectsOfType<TextMeshProUGUI>();
            foreach (TextMeshProUGUI text in texts2)
            {
                text.font = dyslexicFontAsset;
            }
        }
        else if (!options.dyslexiaFriendly){
            Text[] texts = GameObject.FindObjectsOfType<Text>();
            foreach (Text text in texts)
            {
                text.font = normalFont;
            }
            TextMeshProUGUI[] texts2 = GameObject.FindObjectsOfType<TextMeshProUGUI>();
            foreach (TextMeshProUGUI text in texts2)
            {
                text.font = normalFontAsset;
            }

        }
    }

    public void SetFullscreen(bool isFullscreen)
    {
        PlayerPrefs.SetInt("fullscreen", isFullscreen ? 1 : 0);
        Screen.fullScreen = isFullscreen;
        options.fullscreen = isFullscreen;
    }

}
