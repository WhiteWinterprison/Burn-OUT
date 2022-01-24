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
    public bool gameAnimationFinish;

    public bool gameCollision;

 //   public Animator anim;

    public GameObject GoalCollider;

    public Button winButton;
    public bool ButtonPressed = false;



    public AudioSource myAudio;

    bool audioPlay;
    bool a_ToggleChange;


    public Text DebugLog;


    // public Animation BiggerBox;

    // Start is called before the first frame update

    // //////////////////////////////////  STATES //////////////////////////////////////////////////


    WState currentState; // state in der wir uns befinden 


    public  WinIdleState  WinIdle = new WinIdleState();  //first state

    public  ColAnimState ColAnim = new ColAnimState(); // second state  
        
    public  DeadState  Dead = new DeadState(); // end state 

    
     //////////////////////////////////////////////////
    
    void Start()
    {
        currentState = WinIdle; //erste state der aufgerufen werden soll
        currentState.enter(this);

      // anim = GetComponent<Animator>(); // oder unten bei void anim? 

        Button btn = winButton.GetComponent<Button>();
        btn.onClick.AddListener(ButtonClicked);

        myAudio = GetComponent<AudioSource>();
        audioPlay = true;


        
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
  

    public void OnCollisionEnter(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "BiggerBox")  // if collision hits bigger box then game collision true _> switch scene 
        {
            Debug.Log("Collision hits");

            gameCollision = true;
        }
    } 

    
    public void ButtonClicked()
    {
        ButtonPressed = true;
        Debug.Log("ButtonIsPressed");
    }
   
    // animation blume taucht auf 
    /* public void winAnimation()
    {

        // spiel animation ab 

        anim.Play("IsBigger");
        gameAnimationFinish = true; // letzte line
    } */


  


    // game logic collision -> next state -> animation blume 

    //  public void PlayMusic()#
    // public void Music stop

    /* public void LoadScene(string SceneName)
     {
         SceneManager.LoadScene("GameOver");

     }*/

}
