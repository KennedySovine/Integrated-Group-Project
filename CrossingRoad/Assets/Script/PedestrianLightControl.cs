using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianLightControl : MonoBehaviour
{
        public GameObject[] Lights = new GameObject[2];
    public int waitTime = 3;

    // Start is called before the first frame update
    void Start()
    {
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
            yield return new WaitForSeconds(waitTime);
            LightOff();
            Go();
            yield return new WaitForSeconds(waitTime);
        }
  
    }

    void LightOff(){
        for (int i = 0; i < 2; i++)
        {
            Lights[i].GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
        }
    }
    void Stop(){
        Lights[0].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }

    void Go(){
        Lights[1].GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
    }
}
