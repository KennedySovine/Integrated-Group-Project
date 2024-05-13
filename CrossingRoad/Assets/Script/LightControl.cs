using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject[] Lights = new GameObject[3];
    private int waitTime;

    private LevelManager levelManager;

    public bool trafficMoving = false;

    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        waitTime = levelManager.TimeForCrossing;
        StartCoroutine(LightSequence());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LightSequence()
    {
        while (true)
        {
            LightOff();
            Stop();
            trafficMoving = false;
            yield return new WaitForSeconds(waitTime);
            LightOff();
            Ready();
            trafficMoving = true;
            yield return new WaitForSeconds(waitTime / 5);
            LightOff();
            Go();
            yield return new WaitForSeconds(waitTime);
            LightOff();
            SafeStop();
            yield return new WaitForSeconds(waitTime / 5);
        }
  
    }

    void LightOff(){
        for (int i = 0; i < 3; i++)
        {
            Lights[i].GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        }
    }
    void Stop(){
        Lights[0].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }

    void Ready(){
        Lights[0].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        Lights[1].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }

    void Go(){
        Lights[2].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }

    void SafeStop(){
        Lights[1].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }
}
