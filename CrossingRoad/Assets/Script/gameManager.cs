using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{

    public static gameManager Instance;

    public bool lookedLeft = false;
    public bool lookedRight = false;

    public bool mustCheck = true;

    public bool spacePressed = false;

    public bool isMoving = false;

    public Camera[] cameras = new Camera[3];
    private int camNumCurrent = 1;


    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        cameras[0] = GameObject.Find("lookLeft").GetComponent<Camera>();
        cameras[1] = Camera.main;
        cameras[2] = GameObject.Find("lookRight").GetComponent<Camera>();

        cameras[0].enabled = false;
        cameras[2].enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("space key was pressed");
            if (!requirementsMet())
            {
                //Pop up a message bar that tells the player to make sure to check left and right
            }
            else
            {
                spacePressed = true;
                cameras[0].enabled = false;
                cameras[2].enabled = false;
                cameras[1].enabled = true;
            }
        }

        if (camNumCurrent == 0)
        {
            lookedLeft = true;
        }

        if (camNumCurrent == 2)
        {
            lookedRight = true;
        }
    }

    public bool requirementsMet()
    {
        if (!mustCheck)
        {
            return true;
        }
        if (lookedLeft && lookedRight)
        {
            return true;
        }
        return false;
    }

    public void changeCamera(bool side) // True = turn right False = turn left
    {
        if (side)
        {
            if (camNumCurrent == 2)
            {
                return;
            }

            cameras[camNumCurrent].enabled = false;
            camNumCurrent++;
            cameras[camNumCurrent].enabled = true;
            return;
        }

        if (camNumCurrent == 0)
        {
            return;
        }

        cameras[camNumCurrent].enabled = false;
        camNumCurrent--;
        cameras[camNumCurrent].enabled = true;
    }
}
