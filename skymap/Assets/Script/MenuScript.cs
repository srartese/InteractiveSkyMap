using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
	public Canvas creditMenu;
    public Button startText;
    public Button exitText;
    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject enterObj;
    float timeLeft = 5.0f;
   
    //Testing
	// Use this for initialization
   
	void Start () 
    {
        quitMenu = quitMenu.GetComponent<Canvas>();
		creditMenu = creditMenu.GetComponent<Canvas>();

        startText = startText.GetComponent<Button>();
        exitText = exitText.GetComponent<Button>();

        quitMenu.enabled = false;
		creditMenu.enabled = false;

	}

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

	public void CreditPress()
	{
		quitMenu.enabled = false;
		startText.enabled = false;
		exitText.enabled = false;

		creditMenu.enabled = true;
	
	}
	
    public void NoPress()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
	}

	public void BackPress()
	{
		quitMenu.enabled = false;
		startText.enabled = true;
		exitText.enabled = true;
		creditMenu.enabled = false;
	}

    public void StartLevel()
    {
        Application.LoadLevel(1);
        
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void OnCollisionEnter(Collision col)
    {
       
        if (col.gameObject.name == "enterObj")
        {
            Debug.Log("This worked");
            StartLevel();
        }
    }


    public void KinectSelect()
    {
        if (rightHand.transform.position.x > .9f){
            StartLevel();
        }
      
       
    }
  

	// Update is called once per frame
	void Update () 
    {
       // KinectSelect();
         
    }
}
