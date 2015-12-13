using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TestCol : MonoBehaviour
{

    float timeLeft = 3.0f;
    bool collided = false;
    string objName = "";
    public AudioSource source;
    public AudioClip shootSound;
    private float vol = 1.0f;

    public GameObject infoScreen;
    public GameObject selectCube;

    public GameObject cameraObject;
    public GameObject kmCameraObject;
    public GameObject rotateObject;

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
    }

    void Update()
    {
        if (timeLeft > 0 && collided == true)
        {
            timeLeft -= Time.deltaTime;
        }
        else if (timeLeft <= 0)
        {
            Debug.Log("You found " + gameObject.transform.parent.name);
            source.clip = shootSound;
            source.Play();
            collided = false;
            timeLeft = 3.0f;

            //Testing UIs
            infoScreen.SetActive(true);
            cameraScript.enabled = false;
            kmCameraScript.enabled = false;
            orbitScript.enabled = false;
            selectCube.SetActive(false);

            //For enabling boxes
            //gameObject.SetActive(false);
        } else
        {
            timeLeft = 3.0f;
            collided = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.name == "SphereLEFT" || col.gameObject.name == "SphereRIGHT")
        {
            //Debug.Log("Collided " + gameObject.transform.parent.name);
            collided = true;
            objName = gameObject.transform.parent.name;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.name == "SphereLEFT" || col.gameObject.name == "SphereRIGHT")
        {
            //Debug.Log("Lost " + gameObject.transform.parent.name);
            timeLeft = 3.0f;
            collided = false;
        }
    }
}
