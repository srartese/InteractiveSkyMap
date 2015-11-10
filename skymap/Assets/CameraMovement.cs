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
		//if motion null for 2 min, rotatate camera

       /*  if(rightHand.transform.position.x > .5f)
         {
			while (rightHand.transform.position > .5f)
			{

				for( i = 0; i < 1; i++)
				{
					transform.Rotate (Vector3.up, i * Time.deltaTime);

				}
			}
		 */

             //Delta time is calculated by Unity. It gives you the inverse
             //of the framerate. ie 60FPS = Delta time of 1/60. This way you
             //can multiply it against values to ensure they occur at the same
             //speed, regardless of update times.
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
     }
 }
  