using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitCollision : MonoBehaviour {

    float timeLeft = 3.0f;
    bool collided = false;
    string objName = "";
    private float vol = 1.0f;

    public GameObject infoScreen;

    public GameObject cameraObject;
    public GameObject kmCameraObject;
    public GameObject rotateObject;

    private CameraMovement cameraScript;
    private CameraMovement kmCameraScript;
    private Orbit orbitScript;

    // Use this for initialization
    void Start () {
        cameraScript = cameraObject.GetComponent<CameraMovement>();
        kmCameraScript = kmCameraObject.GetComponent<CameraMovement>();
        orbitScript = rotateObject.GetComponent<Orbit>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft > 0 && collided == true)
        {
            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft <= 0)
        {
            //Debug.Log("You found " + gameObject.transform.parent.name);
            collided = false;
            timeLeft = 3.0f;

            //Testing UIs
            infoScreen.SetActive(false);
            cameraScript.enabled = true;
            kmCameraScript.enabled = true;
            orbitScript.enabled = true;
            gameObject.SetActive(false);

            //For enabling boxes
            //gameObject.SetActive(false);
        }
        else
        {
            timeLeft = 3.0f;
            collided = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("Collided " + col.gameObject.name);
        if (col.gameObject.name == "NewSphereRIGHT")
        {
            Debug.Log("Collided " + col.gameObject.name);
            collided = true;
            objName = gameObject.transform.parent.name;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "NewSphereRIGHT")
        {
            //Debug.Log("Lost " + gameObject.transform.parent.name);
            timeLeft = 3.0f;
            collided = false;
        }
    }
}