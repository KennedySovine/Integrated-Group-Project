using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoving : MonoBehaviour
{

    public int xStart;
    private Vector3 startingPosition;
    public bool reverse;

    public float speed = 2;

    private void Start()
    {
        startingPosition = transform.position;
        startingPosition.x = xStart;
    }

    // Update is called once per frame
    void Update()
    {
        if (reverse)
        {
            if (transform.position.x <= -18)
            {
                transform.position = startingPosition;
            }
        }
        else
        {
            if (transform.position.x >= 15)
            {
                transform.position = startingPosition;
            }
        }

        transform.Translate(-Vector3.forward * speed * Time.deltaTime);
    }
}
