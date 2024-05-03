using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookSideButton : MonoBehaviour
{
    private gameManager GM;

    private void Start()
    {
        GM = gameManager.Instance;
    }

    private void Update()
    {
        if (GM.isMoving)
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void LookLeft()
    {
        Debug.Log("Left Click");
        GM.changeCamera(false);
    }

    public void LookRight()
    {
        Debug.Log("Right Click");
        GM.changeCamera(true);
    }
}
