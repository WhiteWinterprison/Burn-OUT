using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//This is the Manager script in here save all the game logic 
public class RayCastManager : MonoBehaviour
{
    // Start is called before the first frame update
    //the I should be substitutet by your own name _______State
    IState currentState; //Importatn Variable !!
    
    
//how to get reverence to the states
   public GameStartedState GameStarted = new GameStartedState();

   public RunGameState RunGame =new RunGameState();
   
    void Start()
    {
        currentState = GameStarted; //erste state der aufgerufen werden soll
        currentState.enter(this); //führe die enter funktion des Scripts aus
    }

    // Update is called once per frame
    void Update()
    {
        currentState.react(this); //WICHTIGE !!! Einzige line in UPdat! HIER KOMMT NIX ANDERS HIN!!!!
    }

 public void switchState(IState nextState) //This will be called when you want to switch a whole state !
    {
        currentState.exit(this);
        currentState = nextState ;
        nextState.enter(this);
    }

    

    //-------------------------------------------------------------------
    //----------------------------Game Logic----------------------------
    //-------------------------------------------------------------------

//add your game logic here :D 
//Every funktion you need can be adde dhere

}
