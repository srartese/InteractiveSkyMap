using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float distance = 20.0f;
    public GameObject hand;
    Vector3 positions;




    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {


        //gameObject.transform.position = new Vector3(hand.transform.position.x * 15, hand.transform.position.y * 12, distance);

        //gameObject.transform.position = new Vector3(hand.transform.position.x, hand.transform.position.y, distance);




        //gameObject.transform.position = Camera.main.WorldToScreenPoint(new Vector3(hand.transform.position.x * 15, hand.transform.position.y * 12, distance));

        positions = Camera.main.WorldToScreenPoint(new Vector3(hand.transform.position.x, hand.transform.position.y, distance));

        gameObject.transform.position = new Vector3(positions.x * .05f, positions.y * .05f, distance);


        ////Working on this below to change camera movements
        //if (hand.transform.position.x > .5f)
        //{
        //    gameObject.transform.position = new Vector3(hand.transform.position.x * 15 * Mathf.Cos(0.349066f), hand.transform.position.y * 12, distance);
        //    //gameObject.transform.Rotate(Vector3.up, 20.0f * Time.deltaTime);
        //}

        //if (hand.transform.position.x < -0.3f)
        //{
        //    gameObject.transform.position = new Vector3(hand.transform.position.x * 15, hand.transform.position.y * 12, distance);
        //    gameObject.transform.Rotate(Vector3.down, 20.0f * Time.deltaTime);
        //}

    }
}
