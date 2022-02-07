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
    public bool gameCollision;


    public GameObject GoalCollider; 

    public Text DebugLog; // for state info 

    public GameObject PlantButton;
    public Button PlantBtn;  // for button appear
    public bool ButtonPressed = false;



    public GameObject[] GameUiParts;  // for ui disappear

    public GameObject[] LeafsUi;   // ui von den leafs verschwinden lasasen 

    public GameObject[] Background; // leaf ui background

    public bool gameAnimationFinish = false;


    [SerializeField] private  Animator myAnimPlantController;  // animator will be shown in inspector
                                                               // [SerializeField] private AnimationClip clip;


    public GameObject TextObj;   // text: accomplished
    float TextShown;
    float TextTime = 8.0f;  // text soll nach 10 sec angezeigt werden weil anim so lange geht

    public GameObject SceneChangeButton;
    public Button SceneChangeBtn;
   // public bool SceneButtonPressed = false;

    // Start is called before the first frame update

    // //////////////////////////////////  STATES //////////////////////////////////////////////////


    WState currentState; // state in der wir uns befinden 


    public WinIdleState WinIdle = new WinIdleState();  //first state

    public ButtonState Button = new ButtonState(); // second state  

    public Lvl0PlantState Lvl0 = new Lvl0PlantState();
    public Lvl1PlantState Lvl1 = new Lvl1PlantState();
    public Lvl2PlantState Lvl2 = new Lvl2PlantState();
    public Lvl3PlantState Lvl3 = new Lvl3PlantState();


    public DeadState Dead = new DeadState(); // end state 

    //////////////////////////////////////////////////

    void Start()
    {
        currentState = WinIdle; //erste state der aufgerufen werden soll
        currentState.enter(this);

       // anim = GetComponent<Animator>(); // oder unten bei void anim? 


        // plant Button
        Button btn = PlantBtn.GetComponent<Button>();
        btn.onClick.AddListener(ButtonClicked);
        PlantButton.gameObject.SetActive(false);  // Button ist nicht angezeigt bzw nicht da 

        GameUiParts = GameObject.FindGameObjectsWithTag("Ui");  // ui verschwinden 
        LeafsUi = GameObject.FindGameObjectsWithTag("Leaf"); // blätter verschwinden 
        Background = GameObject.FindGameObjectsWithTag("Background"); // background verschwinden


        // accomplish text 
        TextObj.SetActive(false);
        TextShown = Time.time;

        // sceneChange Button
        Button Scenebtn = SceneChangeBtn.GetComponent<Button>();
        Scenebtn.onClick.AddListener(ButtonClicked);
        SceneChangeButton.gameObject.SetActive(false);   // noch nicht angezeigt
        //   float length = myAnimPlantController.animator.clip.length;
        // float length = myAnimPlantController.["BiggerBox"].clip.length;
        //float length = GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.length;

       // float length = gameObject.animator.clip.length;
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

    // dritte switch state für deadstate ? oder doch nicht?




    //////////////////// game logic ////////////////

    /// ////////////////////// Collision switch state ////////////////////
    public void OnCollisionEnter(Collision collisionInfo)  //Works
    {
        if (collisionInfo.gameObject.tag == "BiggerBox")  // if collision hits bigger box then game collision true _> switch scene 
        {
            Debug.Log("Collision hits");

            gameCollision = true;

        }
    }

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


    // Button für sceneChange
    public void enableSceneButton()  // works    // button show after state change 
    {
        if (Time.time > TextShown + TextTime) // button soll da seinw enn text da ist 
        {

            SceneChangeButton.gameObject.SetActive(true);
        }

        Debug.Log("Button");
    }
 /*   public void SceneButtonClicked()   // button clicked change scene to animation levels // works
    {

        SceneButtonPressed = true;
        Debug.Log("ButtonIsPressed");
    }
 */
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

    public void GameAnimFinish()
    {

        /*if(myAnimPlantController.GetBool("IsBigger"))
        {
            myAnimPlantController.SetBool("IsBigger", false);
        gameAnimationFinish = true;
        }*/

       /* if(GameObject.FindGameObjectsWithTag("BiggerBox").clip.length ==  100 )
        {
            gameAnimationFinish = true;
        } */
    }

   
    public void TextShownViaTime()
    {
        if(Time.time > TextShown + TextTime)
        {
            TextObj.SetActive(true);
        }
    }
}





