using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianLightControl : MonoBehaviour
{
    public GameObject[] Lights = new GameObject[2];
    public GameObject TrafficLights;

    private LightControl lightControl;

    // Start is called before the first frame update
    void Start()
    {
        
        lightControl = TrafficLights.GetComponent<LightControl>();

    }

    // Update is called once per frame
    void Update()
    {
        if (lightControl.trafficMoving)
        {
            LightOff();
            Stop();
        }
        else if (!lightControl.trafficMoving)
        {
            LightOff();
            Go();
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
