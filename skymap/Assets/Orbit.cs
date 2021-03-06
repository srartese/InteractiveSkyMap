﻿using UnityEngine;
using System.Collections;

public class Orbit : MonoBehaviour {

    GameObject cube;
    public Transform center;
    public Vector3 axis = Vector3.up;
    public Vector3 desiredPosition;
    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;
    public float rotationSpeed = 80.0f;

    //For reading our players hands values
    public GameObject rightHand;
    public GameObject leftHand;


    // Use this for initialization
    void Start () {
        transform.position = (transform.position - center.position).normalized * radius + center.position;
        radius = 2.0f;
    }
	
	// Update is called once per frame
	void Update () {
        
        //Notice these values match the ones in CameraMovement
        //We are having our reference to the user orbit the camera at the same rate at which it moves
        if (rightHand.transform.position.x > .5f)
        {
            transform.RotateAround(center.position, axis, rotationSpeed * Time.deltaTime);
        }

        if (leftHand.transform.position.x < -0.3f)
        {
            transform.RotateAround(center.position, axis, -rotationSpeed * Time.deltaTime);
        }

    }
}
