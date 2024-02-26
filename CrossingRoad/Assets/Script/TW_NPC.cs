using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TW_NPC : MonoBehaviour
{

    int speed = 2;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
