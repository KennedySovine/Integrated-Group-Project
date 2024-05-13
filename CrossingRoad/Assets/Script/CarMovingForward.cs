using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovingForward : MonoBehaviour
{
    private LevelManager levelManager;
    private int stopDistance = 20;
    public float maxSpeed = 20;
    private float currentSpeed = 0;
    private float acceleration = 0.01f;

    public GameObject trafficLight;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 20;
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //If traffic light is red
        if (trafficLight.GetComponent<LightControl>().trafficMoving == false)
        {
            if (Vector3.Distance(transform.position, trafficLight.transform.position) > (stopDistance * 1.05))
            {
                if (currentSpeed > maxSpeed / 1.5)
                {
                    currentSpeed -= acceleration;
                }
            }
            //If the car is within stop distance
            if (Vector3.Distance(transform.position, trafficLight.transform.position) < stopDistance)
            {
                currentSpeed = 0;
            }
        }
        else{
            if (currentSpeed < maxSpeed)
            {
                currentSpeed += acceleration;
            }
        }
        transform.Translate(-Vector3.forward * currentSpeed * Time.deltaTime);

    }
}
