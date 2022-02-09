
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// collision hits -> animation starts 

public class Lvl3PlantState : WState  // collision animation state 
{


    public override void enter(WinningManager gameState)
    {

      //  gameState.disableLeafUi();
  
    }
    public override void react(WinningManager gameState)
    {
        Debug.Log("Lvl3State");
        gameState.disableBackground();
        gameState.disableLeafUi();

        gameState.PlantButton.SetActive(false);

        gameState.Level3Play();
        gameState.TextShownViaTime();
        //  gameState.GameAnimFinish();

        gameState.enableSceneButton();

  

    }
    public override void exit(WinningManager gameState)
    {

        // gamestate.musicstop
    }
}







