using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningManager : MonoBehaviour
{
    // Start is called before the first frame update

    WState currentState; // state in der wir uns befinden 

    public GameObject GoalCollider;

    public WinningIdleState WinIdleState = new WinningIdleState();  //first state

    public CollisionAnimState ColAnimState = new CollisionAnimState(); // second state  
        
    public DeadGameState DeadState = new DeadGameState(); // end state 


    void Start()
    {
        currentState = WinIdleState; //erste state der aufgerufen werden soll
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
