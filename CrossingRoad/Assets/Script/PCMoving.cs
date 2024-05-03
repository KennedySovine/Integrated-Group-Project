using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMoving : MonoBehaviour
{

    public float speed = 2;

    public gameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        GM = gameManager.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if (GM.requirementsMet())
        {
            if (GM.spacePressed)
            {
                GM.isMoving = true;
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
}
