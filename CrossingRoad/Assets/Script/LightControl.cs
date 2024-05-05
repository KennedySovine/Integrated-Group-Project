using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightControl : MonoBehaviour
{
    public GameObject[] Lights = new GameObject[3];

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
            yield return new WaitForSeconds(3.0f);
            LightOff();
            Ready();
            yield return new WaitForSeconds(3.0f);
            LightOff();
            Go();
            yield return new WaitForSeconds(3.0f);
            LightOff();
            SafeStop();
            yield return new WaitForSeconds(3.0f);
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
