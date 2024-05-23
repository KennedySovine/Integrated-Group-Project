using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannotStop : MonoBehaviour
{
    private LevelManager levelManager;
    private GameObject car;

    void Start(){
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            car = other.gameObject;
        }
        Debug.Log("Requirements: " + levelManager.requirementsMet());
        if (levelManager.requirementsMet() || levelManager.isCrossing)
        {
            car.GetComponent<CarMovingForward>().stop = true;
        }
        else if (!levelManager.requirementsMet() || !levelManager.isCrossing)
        {
            car.GetComponent<CarMovingForward>().stop = false;
        }
        
        Debug.Log("Stop: " + car.GetComponent<CarMovingForward>().stop);
    }
}
