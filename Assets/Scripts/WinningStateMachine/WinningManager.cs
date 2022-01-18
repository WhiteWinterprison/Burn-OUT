using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningManager : MonoBehaviour
{
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
    }
    void Update()
    {
        //Nur diesn script im Update. 
        currentState.react(this);

    }
    public void switchState(ColAnimState nextState)
    {
        currentState.exit(this);
        currentState = nextState;
        nextState.enter(this);
    }

    // dritte switch state für deadstate ? oder doch nicht?




   //////////////////// game logic ////////////////
}
