
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// collision hits -> animation starts 

public class Lvl2PlantState : WState  // collision animation state 
{


    public override void enter(WinningManager gameState)
    {
        Debug.Log("EnterAnimState");

    }
    public override void react(WinningManager gameState)
    {

        if (GameObject.FindGameObjectsWithTag("Leaf").Length == 2)
        {
            // play lvl 2 plant
            Debug.Log("2 Leafes left");
            gameState.disableLeafUi();
            gameState.disableBackground();
            gameState.TextShownViaTime();
            //  gameState.GameAnimFinish();

            gameState.enableSceneButton();
            // gameState.Level2Play();
        }




    }
    public override void exit(WinningManager gameState)
    {

        // gamestate.musicstop
    }
}







