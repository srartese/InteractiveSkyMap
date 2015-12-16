using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ExitGameScript : MonoBehaviour {

    //Starting values
    float timeLeft = 4.0f;
    bool collided = false;

    //For the screens that display time to users
    public Text timerText;
    public GameObject timerScreen;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
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

            //Set this colliding object to be off
            gameObject.SetActive(false);

            Application.LoadLevel(0);
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
