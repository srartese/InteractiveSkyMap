using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
//This is named TestCol because I was originally using it as a test, but it unexpectedly succeeded!
public class TestCol : MonoBehaviour
{
    //Starting values
    float timeLeft = 3.0f;
    bool collided = false;

    //For displaying audio
    public AudioSource source;
    public AudioClip shootSound;

    //To activate the screen which shows users interaction times
    public GameObject timerScreen;
    public GameObject selectTimerScreen;
    public Text timerText;

    //Grabs these objects so that we can access their respective scripts and properties
    public GameObject infoScreen;
    public GameObject selectCube;
    public GameObject cameraObject;
    public GameObject kmCameraObject;
    public GameObject rotateObject;

    //Need these scripts so we can de-activate them
    private CameraMovement cameraScript;
    private CameraMovement kmCameraScript;
    private Orbit orbitScript;

    void Start()
    {
        source = GetComponent<AudioSource>();
        cameraScript = cameraObject.GetComponent<CameraMovement>();
        kmCameraScript = kmCameraObject.GetComponent<CameraMovement>();
        orbitScript = rotateObject.GetComponent<Orbit>();
        infoScreen.SetActive(false);
        selectCube.SetActive(false);
        timerText.text = timeLeft.ToString("0.00");
    }

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
            //Once successful, play a sound and reset variables
            Debug.Log("You found " + gameObject.transform.parent.name);
            source.clip = shootSound;
            //source.Play();
            collided = false;
            timeLeft = 3.0f;

            //Reset display and turn it off
            timerText.text = timeLeft.ToString("0.00");
            selectTimerScreen.SetActive(false);

            //Turn off scripts which move the player around
            cameraScript.enabled = false;
            kmCameraScript.enabled = false;
            orbitScript.enabled = false;

            //Turn on the elements to be used in the next screen
            infoScreen.SetActive(true);
            selectCube.SetActive(true);
            timerScreen.SetActive(true);
        } else
        {
            //If failed, reset
            timeLeft = 3.0f;
            collided = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        //If these values collide with the object
        if (col.gameObject.name == "SphereLEFT" || col.gameObject.name == "SphereRIGHT")
        {
            //Debug.Log("Collided " + gameObject.transform.parent.name);

            //Set this variable to true (See aove where it is used)
            collided = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        //If these exit, then we have to stop the countdown
        if (col.gameObject.name == "SphereLEFT" || col.gameObject.name == "SphereRIGHT")
        {
            //Debug.Log("Lost " + gameObject.transform.parent.name);

            //Reset collided and make timeLeft 3.0f again
            timeLeft = 3.0f;
            collided = false;

            //Reset display
            timerText.text = timeLeft.ToString("0.00");
        }
    }
}
