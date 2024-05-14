using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCCollisionManager : MonoBehaviour
{

    private LevelManager levelManager;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //If player is on the crosswalk
        if (collision.gameObject.name == "Crosswalk")
        {
            levelManager.isCrossing = true;
        }

        //If player is hit by a car
        if (collision.gameObject.tag == "Car")
        {
            //Restart scene
            levelManager.RestartScene();
        }
    }
}
