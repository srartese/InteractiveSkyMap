using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitCollision : MonoBehaviour {

    //Starting values
    float timeLeft = 4.0f;
    bool collided = false;

    //For the screens that display time to users
    public Text timerText;
    public GameObject timerScreen;
    public GameObject selectTimerScreen;

    //These are every info screen in game. Used to be disabled
    public GameObject aquariusScreen;
    public GameObject capricornScreen;
    public GameObject sagittariusScreen;
    public GameObject scorpioScreen;
    public GameObject libraScreen;
    public GameObject virgoScreen;
    public GameObject leoScreen;
    public GameObject cancerScreen;
    public GameObject geminiScreen;
    public GameObject taurusScreen;
    public GameObject ariesScreen;
    public GameObject piscesScreen;

    //Grabs these objects so we can access their properties
    public GameObject cameraObject;
    public GameObject kmCameraObject;
    public GameObject rotateObject;
    public GameObject endGameCube;

    //Get scripts so we can re-activate them
    private CameraMovement cameraScript;
    private CameraMovement kmCameraScript;
    private Orbit orbitScript;

    // Use this for initialization
    void Start () {
        cameraScript = cameraObject.GetComponent<CameraMovement>();
        kmCameraScript = kmCameraObject.GetComponent<CameraMovement>();
        orbitScript = rotateObject.GetComponent<Orbit>();
        timerText.text = timeLeft.ToString("0.00");
        timerScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //While the user is colliding with the object, time is going down till they can select
        if (timeLeft > 0 && collided == true)
        {
            timeLeft -= Time.deltaTime;

            //Display this in real time to the user
            timerText.text = timeLeft.ToString("0.00");
        }
        else if (timeLeft <= 0)
        {
            //When succesful, reset variables
            collided = false;
            timeLeft = 4.0f;
            timerText.text = timeLeft.ToString("0.00");

            //Turn off every possible screen
            aquariusScreen.SetActive(false);
            capricornScreen.SetActive(false);
            sagittariusScreen.SetActive(false);
            scorpioScreen.SetActive(false);
            libraScreen.SetActive(false);
            virgoScreen.SetActive(false);
            leoScreen.SetActive(false);
            cancerScreen.SetActive(false);
            geminiScreen.SetActive(false);
            taurusScreen.SetActive(false);
            ariesScreen.SetActive(false);
            piscesScreen.SetActive(false);
            timerScreen.SetActive(false);

            endGameCube.SetActive(true);

            //Turn on the other timer screen now
            selectTimerScreen.SetActive(true);

            //Turn the scripts back on
            cameraScript.enabled = true;
            kmCameraScript.enabled = true;
            orbitScript.enabled = true;

            //Set this colliding object to be off
            gameObject.SetActive(false);
        }
        else
        {
            //If failed, reset
            timeLeft = 4.0f;
            collided = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //If this value collides with the target
        if (col.gameObject.name == "NewSphereRIGHT")
        {
            //Debug.Log("Collided " + col.gameObject.name);
            //Set this to true, so it can be used (See above)
            collided = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        //If it exits, we have to reset the countdown
        if (col.gameObject.name == "NewSphereRIGHT")
        {
            //Debug.Log("Lost " + gameObject.transform.parent.name);

            //Reset variables
            timeLeft = 4.0f;
            collided = false;

            //Reset display
            timerText.text = timeLeft.ToString("0.00");
        }
    }
}