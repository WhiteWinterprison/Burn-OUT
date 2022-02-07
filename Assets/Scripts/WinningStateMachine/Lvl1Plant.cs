
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// collision hits -> animation starts 

public class Lvl1PlantState : WState  // collision animation state 
{


    public override void enter(WinningManager gameState)
    {
        Debug.Log("EnterAnimState");

    }
    public override void react(WinningManager gameState)
    {
        if (GameObject.FindGameObjectsWithTag("Leaf").Length == 1)
        {
            // play lvl 1 plant
            Debug.Log("1 Leafes left");
            gameState.disableLeafUi();
            gameState.disableBackground();
            // gameState.Level1Play();
        }



    }
    public override void exit(WinningManager gameState)
    {

        // gamestate.musicstop
    }
}








