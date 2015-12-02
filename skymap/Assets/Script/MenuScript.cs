using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Button startText;
    public Button exitText;
    public GameObject rightHand;
    public GameObject leftHand;
   

	// Use this for initialization
   
	void Start () 
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();
        quitMenu.enabled = false;
	}

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }
	
    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
	}

    public void StartLevel()
    {
        Application.LoadLevel(1);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void KinectSelect()
    {
        if (rightHand.transform.position.x > .9f)
        {
            StartLevel();
        }
      
       
    }
  

	// Update is called once per frame
	void Update () 
    {
        KinectSelect();
    }
}
