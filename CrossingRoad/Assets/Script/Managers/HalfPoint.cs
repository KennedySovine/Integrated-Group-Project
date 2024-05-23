using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfPoint : MonoBehaviour
{
    public LevelManager levelManager;

    public Vector3 newStartPoint;

    public GameObject newPC;
    public bool newStartPointSet = false;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            levelManager.Reset();
            
            if (newStartPointSet){
                levelManager.Reset();
                levelManager.newPC(newPC);
            }
        }
    }
}
