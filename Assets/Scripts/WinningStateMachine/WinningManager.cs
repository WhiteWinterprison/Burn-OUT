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

    public GameObject PlantButton;

    public Text DebugLog;


    //  public Button winButton;

    // public Button PlantBtn;
    //  public bool ButtonPressed = false;



    public bool gameAnimationFinish;



    // public Animation BiggerBox;

    // Start is called before the first frame update

    // //////////////////////////////////  STATES //////////////////////////////////////////////////


    WState currentState; // state in der wir uns befinden 


    public WinIdleState WinIdle = new WinIdleState();  //first state

    public ButtonState Button = new ButtonState(); // second state  

    public AnimatorState Anim = new AnimatorState(); // third state  

    public DeadState Dead = new DeadState(); // end state 


    //////////////////////////////////////////////////

    void Start()
    {
        currentState = WinIdle; //erste state der aufgerufen werden soll
        currentState.enter(this);

        //anim = GetComponent<Animator>(); // oder unten bei void anim? 

        // Button btn = PlantBtn.GetComponent<Button>();
        //  btn.onClick.AddListener(ButtonClicked);
        PlantButton.gameObject.SetActive(false);  // Button ist nicht angezeigt bzw nicht da 



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



    public void enableButton()  // works
    {

        PlantButton.gameObject.SetActive(true);
        Debug.Log("Button");
    }

    public void disappearUi()  //ui muss mit tag gesetzt werden zum zerstören //works
    {
        Destroy(GameObject.FindWithTag("Ui"));
    }

    /*  public void ButtonClicked()   // later for button to plant
      {

          ButtonPressed = true;
          Debug.Log("ButtonIsPressed");
      } */


    ////////////////////////// ANIMATION /////////////////////////

    // animation blume taucht auf 
    public void winAnimation()
    {

        // spiel animation ab 

        //anim.Play("IsBigger");

        gameAnimationFinish = true; // letzte line
    }



    /////////////// Music (when win a sound should drop)////////////////////7

    // game logic collision -> next state -> animation blume 

    //  public void PlayMusic()#
    // public void Music stop

    /* public void LoadScene(string SceneName)
     {
         SceneManager.LoadScene("GameOver");

     }*/

}





