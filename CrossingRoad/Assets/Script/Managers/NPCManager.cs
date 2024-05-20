using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    private LevelManager levelManager;

    public GameObject[] npcPrefabs = new GameObject[6];

    public GameObject parentObj;

    public GameObject[] npcs = new GameObject[30];

    [Header("NPC Parameters")]
    public float minZ;
    public float maxZ;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        makeNPCs();
    }

    // Update is called once per frame
    void Update()
    {
        remakeNPCs();
        
    }

    public float newSpeed(){
        float speed = Random.Range(3.0f, 5.0f);
        return speed;
    }

    private void makeNPCs(){
        for (int i = 0; i < 30; i++){
            npcs[i] = Instantiate(npcPrefabs[Random.Range(0, npcPrefabs.Length-1)], new Vector3(Random.Range(-145, 145), 3.5f, Random.Range(minZ, maxZ)), Quaternion.identity);
            //Rotate if reverse
            bool reverse = npcs[i].GetComponent<NPCMoving>().reverse;
            Quaternion rotation = reverse ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
            npcs[i].transform.rotation = rotation;
            //Parent
            npcs[i].transform.SetParent(parentObj.transform);
            npcs[i].GetComponent<NPCMoving>().speed = newSpeed();
        }
    }

    private void remakeNPCs(){
        for (int i = 0; i < 30; i++){
            if (!npcs[i].activeInHierarchy){
                if (npcs[i].GetComponent<NPCMoving>().reverse){
                    npcs[i].transform.position = new Vector3(150, 3.5f, Random.Range(minZ, maxZ));
                }
                else{
                    npcs[i].transform.position = new Vector3(-150, 3.5f, Random.Range(minZ, maxZ));
                }
                npcs[i].GetComponent<NPCMoving>().speed = newSpeed();
                npcs[i].SetActive(true);
            }
        }
    }
}
