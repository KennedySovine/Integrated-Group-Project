using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovingForward : MonoBehaviour
{
    private LevelManager levelManager;
    private int stopDistance = 10;
    public float maxSpeed = 20;
    public bool stop = true;
    private float currentSpeed = 0;
    private float acceleration = 0.01f;

    private bool canAccelerate = true;

    public GameObject trafficLight;
    public GameObject crosswalk;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = 20;
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        trafficLight = FindNearestWithTag("Light");
    }

    // Update is called once per frame
    void Update()
    {
        if (stop){
        //If a zebra light
        if (trafficLight.GetComponent<LightControl>() == null ){
            if (levelManager.requirementsMet() || levelManager.isCrossing){
                //Slowdown car
                if (Vector3.Distance(transform.position, trafficLight.transform.position) > (stopDistance * 1.75))
                {
                    if (currentSpeed > maxSpeed / 1.5)
                    {
                        Debug.Log("Slowing down");
                        currentSpeed -= acceleration;
                        canAccelerate = false;
                    }
                }
                //Stop car
                if (Vector3.Distance(transform.position, trafficLight.transform.position) < stopDistance)
                {
                    currentSpeed = 0;
                
                }
            }
            else{
                canAccelerate = true;
            }
        }
        //If traffic light is red
        else if (trafficLight.GetComponent<LightControl>().trafficMoving == false)
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
            else{
                canAccelerate = true;
            }
        }
        else {
            canAccelerate = true;
        }
        if (currentSpeed < maxSpeed && canAccelerate)
        {
            currentSpeed += acceleration;
        }

        }
        else{
            canAccelerate = true;
            if (currentSpeed < maxSpeed && canAccelerate)
            {
                currentSpeed += acceleration;
            }
        }
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);

        if (transform.position.x > 150 || transform.position.x < -150)
        {
            Destroy(gameObject);
        }
        

    }

    private GameObject FindNearestWithTag(string tag)
{
    GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(tag);
    GameObject closest = null;
    float closestDistance = Mathf.Infinity;

    foreach (GameObject obj in taggedObjects)
    {
        float newDistance = Vector3.Distance(transform.position, obj.transform.position);
        if ( newDistance < closestDistance)
        {
            closestDistance = newDistance;
            closest = obj;
        }
    }
    return closest;
}

    public void setStop(bool stop){
        this.stop = stop;
    }
}
