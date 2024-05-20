using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMainMenu : MonoBehaviour
{
    public bool reverse;

    public float speed;

    private NPCManager npcmanager;

    public int minX;
    public int maxX;

    private void Start()
    {
        npcmanager = GameObject.Find("LevelManager").GetComponent<NPCManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (reverse)
        {
            if (transform.position.x <= minX)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (transform.position.x >= maxX)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
