using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TestCol : MonoBehaviour {

	void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "HANDLEFT")
        {
           // Destroy(col.gameObject);
            Debug.Log("Good");
        }



    }
}
