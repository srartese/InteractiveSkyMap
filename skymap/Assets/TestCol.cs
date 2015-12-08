using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class TestCol : MonoBehaviour
{

    float timeLeft = 4.0f;
    bool collided = false;
    string objName = "";
    public AudioSource source;
    public AudioClip shootSound;
    private float vol = 1.0f;

    public GameObject infoScreen;


    void Start()
    {
        source = GetComponent<AudioSource>();
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
            timeLeft = 4.0f;
            infoScreen.SetActive(true);
        } else
        {
            timeLeft = 4.0f;
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
            timeLeft = 4.0f;
            collided = false;
        }
    }
}
