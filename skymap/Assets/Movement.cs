using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public GameObject hand;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //Simple enough: This object is following our reference to the user
        //This was needed because we have three references to the user which could cause errors
        gameObject.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y, hand.transform.position.z);
    }
}
