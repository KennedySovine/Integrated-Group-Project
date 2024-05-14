using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    gameManager GM;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        GM = gameManager.Instance;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerPrefs.SetInt("completedScenes", PlayerPrefs.GetInt("completedScenes") + 1);
        GM.loadNextScene();
    }
}
