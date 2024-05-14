using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookButton : MonoBehaviour
{
    GameObject Camera;
    // Start is called before the first frame update
    void Start()
    {
        Camera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lookLeft() {
        Camera.transform.Rotate(new Vector3(0, -82, 0));
    }

    public void lookRight() { }
}
