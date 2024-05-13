using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoving : MonoBehaviour
{
    public Vector3 startingPosition;
    public bool reverse;

    private float speed;

    private void Start()
    {
        startingPosition = transform.position;
        if (reverse){
            startingPosition.x = 150;
        }
        else{
            startingPosition.x = -150;
        }
        newSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        if (reverse)
        {
            if (transform.position.x <= -150)
            {
                transform.position = startingPosition;
                newSpeed();
            }
        }
        else
        {
            if (transform.position.x >= 150)
            {
                transform.position = startingPosition;
                newSpeed();
            }
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
    private void newSpeed(){
        speed = Random.Range(3.0f, 5.0f);
    }
}
