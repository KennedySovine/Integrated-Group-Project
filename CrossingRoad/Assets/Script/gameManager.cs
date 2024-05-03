using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{

    public bool lookedLeft = false;
    public bool lookedRight = false;

    public bool mustCheck = true;

    public bool spacePressed = false;

    public Camera[] cameras = new Camera[3];
    private int camNumCurrent = 1;

    // Start is called before the first frame update
    void Start()
    {
        
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
            }
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

            camNumCurrent++;
            return;
        }
        if (camNumCurrent == 0)
        {
            return;
        }
        camNumCurrent--;
    }
}
