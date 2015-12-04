using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public GameObject hand;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        gameObject.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y, hand.transform.position.z);
    }
}
