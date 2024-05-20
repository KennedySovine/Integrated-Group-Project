using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProximity : MonoBehaviour
{
    public float activation_distance = 2;
    public string message = "message here";
    public GameObject message_panel;
    public Text text_panel;
    public GameObject PC;


    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(PC.transform.position, transform.position) < activation_distance)
        {
            message_panel.SetActive(true);
            text_panel.text = message;
        }
        else if (Vector3.Distance(PC.transform.position, transform.position) < activation_distance + 1)
        {
            message_panel.SetActive(false);
        }
    }
}
