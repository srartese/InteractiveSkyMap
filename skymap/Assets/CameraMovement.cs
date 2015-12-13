using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
    public GameObject rightHand;
    public GameObject leftHand;


    public void Start () {
    }

     public void Update()
     {
        //When the users hands are at these x values
        if (rightHand.transform.position.x > .5f)
         {
             //Move the camera in that direction
             transform.Rotate(Vector3.up, 20.0f * Time.deltaTime);
         }

         if(leftHand.transform.position.x < -0.3f)
         {
             //transform.Rotate(Vector3.down, 1.0f);
             transform.Rotate(Vector3.down, 20.0f * Time.deltaTime);
         }

        //if(leftHand.transform.position.y < 1.2f)
        // {
        //     transform.Rotate(Vector3.up, 20.0f * Time.deltaTime);

        // }


		//Seclting objects will deal with depth
		//Adding in a timer for selecting and world rotation


     }
 }
  