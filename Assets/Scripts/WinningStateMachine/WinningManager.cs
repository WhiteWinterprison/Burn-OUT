using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;
using UnityEngine.Audio;


public class WinningManager : MonoBehaviour
{
    // public bool gameCollision; [SerializeField] private

    //-------------------Debugs--------------
    public Text DebugLog; // for state info 
    public Text DebugLogCollision;
    public Text DebugLogInCollision;

    //----------------Collision------------
    [HideInInspector] public bool gameCollision = false;
    public GameObject GoalCollider; 

    //----------ButtonRev-----------
    public GameObject PlantButton; //WARUM 2 MAL ??
    public Button PlantBtn;  // for button appear
    [HideInInspector] public bool ButtonPressed = false;
    public GameObject SceneChangeButton;
    public Button SceneChangeBtn;

    //-----------Ui Part Rev --------------
    public GameObject[] GameUiParts;  // for ui disappear //WARUM " MAL ???
    public GameObject[] LeafsUi;   // ui von den leafs verschwinden lasasen 
    public GameObject[] Background; // leaf ui background

    //------------------Rev by Isabel----------------
    [SerializeField] private Camera ARCamera;
    [HideInInspector] public PCManager CollisionInfo;

    
    [SerializeField] private  Animator myAnimPlantController;  // animator will be shown in inspector
                                                               // [SerializeField] private AnimationClip clip;

    //-----Winning UI ADDS-----------------
    public GameObject TextObj;   // text: accomplished
    float TextShown;
    float TextTime = 8.0f;  // text soll nach 10 sec angezeigt werden weil anim so lange geht

   

    // //////////////////////////////////  STATES //////////////////////////////////////////////////

    WState currentState; // state in der wir uns befinden 


    public WinIdleState WinIdle = new WinIdleState();  //first state

    public ButtonState Button = new ButtonState(); // second state  

    public Lvl0PlantState Lvl0 = new Lvl0PlantState();
    public Lvl1PlantState Lvl1 = new Lvl1PlantState();
    public Lvl2PlantState Lvl2 = new Lvl2PlantState();
    public Lvl3PlantState Lvl3 = new Lvl3PlantState();

    //////////////////////////////////////////////////

    void Start()
    {
        currentState = WinIdle; //erste state der aufgerufen werden soll
        currentState.enter(this); 

        // plant Button
        Button btn = PlantBtn.GetComponent<Button>();
        btn.onClick.AddListener(ButtonClicked);
        PlantButton.gameObject.SetActive(false);  // Button ist nicht angezeigt bzw nicht da 

        GameUiParts = GameObject.FindGameObjectsWithTag("Ui");  // ui verschwinden 
        LeafsUi = GameObject.FindGameObjectsWithTag("Leaf"); // blaetter verschwinden 
        Background = GameObject.FindGameObjectsWithTag("Background"); // background verschwinden

        // accomplish text 
        TextObj.SetActive(false);
        TextShown = Time.time;

        // sceneChange Button
        Button Scenebtn = SceneChangeBtn.GetComponent<Button>();
        Scenebtn.onClick.AddListener(ButtonClicked);
        SceneChangeButton.gameObject.SetActive(false);   // noch nicht angezeigt
    
        //Isabel:
        GameObject CollisionManager = GameObject.Find("CollisionManager");
        CollisionInfo = CollisionManager.GetComponent<PCManager>();
    }
    void Update()
    {
        //Nur diesn script im Update. 
        currentState.react(this);

    }
    public void switchState(WState nextState)  //erlaubt szenenn switch
    {
        currentState.exit(this);
        currentState = nextState;
        nextState.enter(this);
    }

    // dritte switch state f???r deadstate ? oder doch nicht?


    //////////////////// game logic ////////////////

    /// ////////////////////// Collision switch state ////////////////////
    
    // public void OnCollisionEnter(Collision collisionInfo)
    // {
    //     DebugLogInCollision.text = "INCollision";

    //     if (collisionInfo.transform.tag == "BiggerBox")  // if collision hits bigger box then game collision true _> switch scene 
    //     {
    //         Debug.Log("Collision hits");
         
    //         gameCollision = true;
           
    //     }
    // }  
    // public void OnCollisionExit(Collision collisionInfo) 
    // {
    //     DebugLogInCollision.text = "OutCOl";

    //     if (collisionInfo.transform.tag == "BiggerBox")  // if collision hits bigger box then game collision true _> switch scene 
    //     {
    //         gameCollision = false;
    //         DebugLogInCollision.text = "OutCollision";
    //     }
    // }

    //Isabel:
    //Get collision infrom from PC manager
    public void GetCollisionInfo()
    {
        if(CollisionInfo.isWinning == true)
        {
            gameCollision = true;
        }
    }


    //--------------RayCast Collison try----------------------
    

    // ////////// BUTTON ////////////

    public void enableButton()  // works    // button show after state change 
    {

        PlantButton.gameObject.SetActive(true);
        Debug.Log("Button");
    }
    public void ButtonClicked()   // button clicked change scene to animation levels // works
    {

        ButtonPressed = true;
        Debug.Log("ButtonIsPressed");
    }


    // Button f???r sceneChange
    public void enableSceneButton()  // works    // button show after state change 
    {
        if (Time.time > TextShown + TextTime) // button soll da seinw enn text da ist 
        {

            SceneChangeButton.gameObject.SetActive(true);
        }

        Debug.Log("Button");
    }
    /// /////// DISABLE UI /////// 

    public void disableGameUi() // works   // game ui will be disabled after collision hits
    {
        GameUiParts = GameObject.FindGameObjectsWithTag("Ui");

        foreach (GameObject GameUi in GameUiParts)
        {
            GameUi.SetActive(false);

        }
    }
    
    public void disableLeafUi() // works    // after button pressed leafs will disappear
    {
        GameUiParts = GameObject.FindGameObjectsWithTag("Leaf");

        foreach (GameObject Leaf in LeafsUi)
        {
            Leaf.SetActive(false);

        }
    } 
    
    public void disableBackground() // works    // after button pressed leafs will disappear
    {
        GameUiParts = GameObject.FindGameObjectsWithTag("Background");

        foreach (GameObject BackgroundUi in Background)
        {
            BackgroundUi.SetActive(false);

        }
    }

   
    ////////////////////////// ANIMATION /////////////////////////
    // WORKS//////////////////
    public void Level3Play()     // animation for level 3 play
    {
        if (ButtonPressed == true)
        {
            myAnimPlantController.SetBool("IsBigger", true);
        }
        
        if (ButtonPressed == false)
        {
            myAnimPlantController.SetBool("IsBigger", false);
        }
    }
    /*  public void Level2Play()   // animation for level 2 play
    {
        if (ButtonPressed == true)
        {
            myAnimPlantController.SetBool("IsBigger", true);
        }
        
        if (ButtonPressed == false)
        {
            myAnimPlantController.SetBool("IsBigger", false);
        }
    } 
      public void Level1Play()  // animation for level 1 play
    {
        if (ButtonPressed == true)
        {
            myAnimPlantController.SetBool("IsBigger", true);
        }
        
        if (ButtonPressed == false)
        {
            myAnimPlantController.SetBool("IsBigger", false);
        }
    } */

    public void Level0Play()  // animation f0r level 0 play 
    {
        if (ButtonPressed == true)
        {
            myAnimPlantController.SetBool("IsSideMove", true);
        }
        
        if (ButtonPressed == false)
        {
            myAnimPlantController.SetBool("IsSideMove", false);
        }
    }


    public void TextShownViaTime()
    {
        if(Time.time > TextShown + TextTime)
        {
            TextObj.SetActive(true);
        }
    }
}





