using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMoving : MonoBehaviour
{

    public float speed = 2;

    public LevelManager LM;

    // Start is called before the first frame update
    void Start()
    {
        LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (LM.requirementsMet())
        {
            if (LM.spacePressed)
            {
                LM.isMoving = true;
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
}
