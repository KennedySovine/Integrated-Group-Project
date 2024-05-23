using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LookSideButton : MonoBehaviour
{
    private LevelManager LM;
    private Button button;

    private void Start()
    {
        button = gameObject.GetComponent<Button>();

        LM = GameObject.Find("LevelManager").GetComponent<LevelManager>();
    }

    private void Update()
    {
        if (GameObject.Find("LevelManager").GetComponent<ScrollingText>().enabled && button != null)
        {
            button.interactable = false;
        }
        else{
        if (button != null && button.interactable)
        {
            if (LM.isMoving)
            {
                button.interactable = false;
            }
        }
        else if (button != null && !button.interactable)
        {
            if (!LM.isMoving)
            {
                button.interactable = true;
            }
        }
        }
    }

    public void LookLeft()
    {
        LM.changeCamera(false);
    }

    public void LookRight()
    {
        LM.changeCamera(true);
    }
}
