using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private gameManager GM;

[Header("Crossing Parameters")]
    public bool lookedLeft = false;
    public bool lookedRight = false;

    public bool mustCheck = true;
    public bool spacePressed = false;
    public bool isMoving = false;

    public bool carsStop = true;

    public bool isCrossing = false;

    public int TimeForCrossing = 10; //Time it takes for the lights to change


[Header("Camera Parameters")]
    [SerializeField] Camera[] cameras = new Camera[3];
    private int camNumCurrent = 1;

[Header("Pop-Up Parameters")]
    public GameObject popUp;
    public Text popUpText;

[Header("Tutorial Parameters")]
    [SerializeField] private GameObject tutorialPanel;

[Header("Car Paremeters")]
    public GameObject[] car = new GameObject[3];
    public GameObject[] carSpawns = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {

        GM = gameManager.Instance;
        cameras[0].enabled = false;
        cameras[2].enabled = false;

        tutorialPanel.SetActive(true);

        spawnCar();
    }

    // Update is called once per frame
    void Update()
    {

        spawnCar();

        if (!gameObject.GetComponent<ScrollingText>().enabled)
        {
            tutorialPanel.SetActive(false);
            if (!isMoving){
                if (Input.GetKeyDown("left")){
                    changeCamera(false);
                }
                else if (Input.GetKeyDown("right")){
                    changeCamera(true);
                }
            }
            
            // Check for space bar press only if ScrollingText script is not enabled
            if (Input.GetKeyDown("space"))
            {
                Debug.Log("space key was pressed");
                if (!requirementsMet())
                {
                    StartCoroutine(CheckMessage());
                }
                else
                {
                    spacePressed = true;
                    cameras[0].enabled = false;
                    cameras[2].enabled = false;
                    cameras[1].enabled = true;
                }
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

//check if the player has looked left and right
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

//change the camera view
    public void changeCamera(bool side) // True = turn right False = turn left
    {
        Debug.Log(side);
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
        else{

            if (camNumCurrent == 0)
            {
                return;
            }

            cameras[camNumCurrent].enabled = false;
            camNumCurrent--;
            cameras[camNumCurrent].enabled = true;
        }
    }

    public void spawnCar(){
        int carNum;

        if (carSpawns.Length == 0)
        {
            return;
        }   

        //Car on the left
        if (carSpawns[0] == null)
        {
            carNum = Random.Range(0, 3);
            carSpawns[0] = Instantiate(car[carNum], new Vector3 (-145, 3, 17.68f), Quaternion.identity);
            if (carNum == 1) {
                carSpawns[0].transform.Rotate(0, -90, 0);
            } 
            else {
                carSpawns[0].transform.Rotate(0, 90, 0);
            }
            if (!carsStop){
                carSpawns[0].GetComponent<CarMovingForward>().stop = false;
            }
        }

        if (carSpawns[1] == null){
            //Car on the right
            carNum = Random.Range(0, 3);
            carSpawns[1] = Instantiate(car[carNum], new Vector3 (145, 3, 7), Quaternion.identity);
            if (carNum == 1) {
                carSpawns[1].transform.Rotate(0, -270, 0);
            } 
            else {
                carSpawns[1].transform.Rotate(0, -90, 0);
            }

            if (!carsStop){
                carSpawns[1].GetComponent<CarMovingForward>().stop = false;
            }
        }
    }

    public void Reset(){
        lookedLeft = false;
        lookedRight = false;
        spacePressed = false;
        isMoving = false;
        isCrossing = false;
    }

    public void newPC(GameObject newpc){
        Destroy(GameObject.Find("PC"));
        newpc.SetActive(true);
        cameras[0] = GameObject.Find("lookLeft1").GetComponent<Camera>();
        cameras[1] = GameObject.Find("MC").GetComponent<Camera>();
        cameras[2] = GameObject.Find("lookRight1").GetComponent<Camera>();

        cameras[0].enabled = false;
        cameras[2].enabled = false;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    IEnumerator CheckMessage()
    {
        popUpText.text = "You must look left and right before crossing!";
        popUp.SetActive(true);
        Debug.Log("Before Waiting 3 seconds");
        yield return new WaitForSeconds(3);
        Debug.Log("After Waiting 3 Seconds");
        popUp.SetActive(false);
    }
}
