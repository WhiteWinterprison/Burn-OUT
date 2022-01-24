using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningManager : MonoBehaviour
{
    public bool gameAnimationFinish;

    public bool gameCollision;

    public Animation anim; 

    // Start is called before the first frame update

    WState currentState; // state in der wir uns befinden 

    public GameObject GoalCollider;

    public  WinIdleState  WinIdle = new WinIdleState();  //first state

    public  ColAnimState ColAnim = new ColAnimState(); // second state  
        
    public  DeadState  Dead = new DeadState(); // end state 


    void Start()
    {
        currentState = WinIdle; //erste state der aufgerufen werden soll
        currentState.enter(this);

        anim = GetComponent<Animation>(); // oder unten bei void anim? 
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
  

    public void OnCollisionEnter()
    {
        // coliisssion definieren 
        gameCollision = true; 
    }

    public void winAnimation()
    {
        // spiel animation ab 
        anim.Play("BiggerBox");   
        gameAnimationFinish = true; // letzte line
    }
    // game logic collision -> next state -> animation blume 

   //  public void PlayMusic()#
   // public void Music stop
}
