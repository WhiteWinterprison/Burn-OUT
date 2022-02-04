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


     public Button PlantBtn;  // for button appear
     public bool ButtonPressed = false;

    public GameObject PlantButton;


    public GameObject[] GameUiParts;  // for ui disappear

    public GameObject[] Leafleft; /// how many leafs are left for counting in scene to change state 

    public GameObject[] LeafsUi;   // ui von den leafs verschwinden lasasen 

   // animation disable and enable at state????




    public bool gameAnimationFinish;   // for animation finish change scene



    // public Animation BiggerBox;

    // Start is called before the first frame update

    // //////////////////////////////////  STATES //////////////////////////////////////////////////


    WState currentState; // state in der wir uns befinden 


    public WinIdleState WinIdle = new WinIdleState();  //first state

    public ButtonState Button = new ButtonState(); // second state  

    public Lvl0PlantState Lvl0 = new Lvl0PlantState();
    public Lvl1PlantState Lvl1 = new Lvl1PlantState();
    public Lvl2PlantState Lvl2 = new Lvl2PlantState();
    public Lvl3PlantState Lvl3 = new Lvl3PlantState();

    
    public AnimatorState Anim = new AnimatorState(); // third state  

    public DeadState Dead = new DeadState(); // end state 


    //////////////////////////////////////////////////

    void Start()
    {
        currentState = WinIdle; //erste state der aufgerufen werden soll
        currentState.enter(this);

        //anim = GetComponent<Animator>(); // oder unten bei void anim? 

        Button btn = PlantBtn.GetComponent<Button>();
        btn.onClick.AddListener(ButtonClicked);
        PlantButton.gameObject.SetActive(false);  // Button ist nicht angezeigt bzw nicht da 

        GameUiParts = GameObject.FindGameObjectsWithTag("Ui");
        LeafsUi = GameObject.FindGameObjectsWithTag("Leaf");


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

    public void enableButton()  // works
    {

        PlantButton.gameObject.SetActive(true);
        Debug.Log("Button");
    }

/// /////// DISABLE UI /////// 

    public void disableGameUi() // works 
    {
        GameUiParts = GameObject.FindGameObjectsWithTag("Ui");

        foreach (GameObject GameUi in GameUiParts)
        {
            GameUi.SetActive(false);

        }
    }
    
    public void disableLeafUi() // works 
    {
        GameUiParts = GameObject.FindGameObjectsWithTag("Leaf");

        foreach (GameObject Leaf in LeafsUi)
        {
            Leaf.SetActive(false);

        }
    }

     public void ButtonClicked()   // button clicked change scene to animation 
      {
         
          ButtonPressed = true;
          Debug.Log("ButtonIsPressed");
      } 


    ////////////////////////// ANIMATION /////////////////////////


   /* public void AnimationWithTag()    // iwas mit finde den tag und dann spiel auf deisem object wo tag ist die animation ab 
    {
       if( GameObject.FindGameObjectsWithTag("AnimationPlant") == true)
        {
            anim.play("PlantAnimLvl3");
        }
    } */
    // animation blume taucht auf 
   /* public void winAnimation()
    {

        // spiel animation ab 

        //anim.Play("IsBigger");

        /*if(GameObject.FindGameObjectsWithTag("Leaf").Length < 3)  // depending how many leafs are left play anim // < less than 3 leafs // or = 3 and = 2 and = 1?  
        {
            // play this anim 
        } */


        //creating extra state
        // will be detected but when button is pressed ui disappear so then at the end no leafs will be left hmmm
       /* if (GameObject.FindGameObjectsWithTag("Leaf").Length < 3)
        {
            // play lvl 3 plant
            Debug.Log("all Leafes left");
        }

        // depending on leaf left specific anim will be played 
        // if one leaf left play this anim etc 

      //  gameAnimationFinish = true; // letzte line
    } */



    /////////////// Music (when win a sound should drop)////////////////////7

    // game logic collision -> next state -> animation blume 

    //  public void PlayMusic()#
    // public void Music stop

    /* public void LoadScene(string SceneName)
     {
         SceneManager.LoadScene("GameOver");

     }*/

}





