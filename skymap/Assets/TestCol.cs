using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestCol : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "SphereLEFT" || col.gameObject.name == "SphereRIGHT")
        {
            Debug.Log("You found " + gameObject.transform.parent.name);
        }



    }
}
