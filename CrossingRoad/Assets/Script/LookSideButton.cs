using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LookSideButton : MonoBehaviour
{
    private LevelManager LM;

    private void Start()
    {
        LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        Button button = gameObject.GetComponent<Button>();
        if (button != null && button.interactable)
        {
            if (LM.isMoving)
            {
                button.interactable = false;
            }
        }
    }

    public void LookLeft()
    {
        Debug.Log("Left Click");
        LM.changeCamera(false);
    }

    public void LookRight()
    {
        Debug.Log("Right Click");
        LM.changeCamera(true);
    }
}
