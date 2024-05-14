using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoving : MonoBehaviour
{
    public bool reverse;

    public float speed;

    private NPCManager npcmanager;

    private void Start()
    {
        npcmanager = GameObject.Find("LevelManager").GetComponent<NPCManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reverse)
        {
            if (transform.position.x <= -150)
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (transform.position.x >= 150)
            {
                gameObject.SetActive(false);
            }
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
