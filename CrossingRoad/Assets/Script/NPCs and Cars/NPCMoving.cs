using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMoving : MonoBehaviour
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
                gameObject.SetActive(false);
            }
        }
        else
        {
            if (transform.position.x >= maxX)
            {
                gameObject.SetActive(false);
            }
        }

        transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
