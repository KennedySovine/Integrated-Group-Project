using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMoving : MonoBehaviour
{

    public float speed = 2;

    public GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<gameManager>().requirementsMet())
        {
            if (gameManager.GetComponent<gameManager>().spacePressed)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }
        }
    }
}
