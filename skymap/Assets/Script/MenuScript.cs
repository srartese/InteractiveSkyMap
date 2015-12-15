using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuScript : MonoBehaviour {

    //Canvas menu Items
    public GameObject quitMenu;
	public GameObject creditMenu;
    public GameObject startMenu;

    //Input from the user
    public GameObject rightHand;
    public GameObject leftHand;
    
    //Time values and initialization
    float timeLeft = 4.0f;
    bool collided = false;
    public GameObject timerScreen;
    public GameObject selectTimerScreen;
    public Text timerText;
    
    //Boxes for collisions
    public GameObject colEnter;
    public GameObject colExit;
    public GameObject colCredits;
    public GameObject colBack;
    public GameObject colNo;
    public GameObject colYes;



   
	void Start () 
    {

        timerText.text = timeLeft.ToString("0.00");
	}

    public void ExitPress()
    {
        startMenu.SetActive(false);

        //Disables collisions for main menu
        colEnter.SetActive(false);
        colExit.SetActive(false);
        colCredits.SetActive(false);


        //Enables collisions for needed buttons
        colNo.SetActive(true);
        colYes.SetActive(true);
        quitMenu.SetActive(true);
        //colBack.SetActive(true);


    }

	public void CreditPress()
	{
        quitMenu.SetActive(false);
        startMenu.SetActive(false);

        creditMenu.SetActive(true);

        //Collisions
        colEnter.SetActive(false);
        colExit.SetActive(false);
        colCredits.SetActive(false);
        colBack.SetActive(true);
	}
	
    public void NoPress()
    {
        quitMenu.SetActive(false);
        startMenu.SetActive(true);

        //Enables collisions needed and disables others
        colBack.SetActive(false);
        colNo.SetActive(false);
        colYes.SetActive(false);
        colEnter.SetActive(true);
        colExit.SetActive(true);
        colCredits.SetActive(true);
	}

	public void BackPress()
	{
        quitMenu.SetActive(false);
        startMenu.SetActive(true);
        creditMenu.SetActive(false);

        //Disables and enables collisions
        colBack.SetActive(false);
        colNo.SetActive(false);
        colYes.SetActive(false);
        colEnter.SetActive(true);
        colExit.SetActive(true);
        colCredits.SetActive(true);
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
        //If these calues collide with the object
        if (col.gameObject.name == "SphereLEFT" || col.gameObject.name == "SphereRIGHT")
        {
            collided = true;
            Debug.Log("Collided " + gameObject.transform.name);

        }
    
    }

    void OnCollisionExit(Collision col)
    { 
        //If these exit, then we have to stop the countdown
        if (col.gameObject.name == "SphereLEFT" || col.gameObject.name == "SphereRIGHT")
        {
            timeLeft = 4.0f;
            collided = false;

            timerText.text = timeLeft.ToString("0.00");
        }
    }

    
	// Update is called once per frame
	void Update () 
    {
     //While user is colliding with the object, time is going down until they can select
        if(timeLeft > 0 && collided == true)
        {
            timeLeft -= Time.deltaTime;

            Debug.Log(timeLeft);

            //Display in real time to the user
            timerText.text = timeLeft.ToString("0.00");
        }

        else if (timeLeft <= 0)
        {

            switch (gameObject.transform.name)
            {
                case "ColEnter":
                    StartLevel();
                    break;
                case "ColExit":
                    ExitPress();
                    break;
                case "ColCredits":
                    CreditPress();
                    break;
                case "ColBack":
                    BackPress();
                    break;
                case "ColNo":
                    NoPress();
                    break;
                case "ColYes":
                    ExitGame();
                    break;
                default:
                    break;
            }

            collided = false;
            timeLeft = 4.0f;
            timerText.text = timeLeft.ToString("0.00");

        }
        else
        {
            timeLeft = 4.0f;
            collided = false;
        }
         
    }
}
