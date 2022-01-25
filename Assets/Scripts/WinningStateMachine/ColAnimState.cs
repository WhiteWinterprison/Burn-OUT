using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// collision hits -> animation starts 

public class ColAnimState : WState  // collision animation state 
{

    public override void enter(WinningManager gameState)
    {
        Debug.Log("EnterAnimState");

       
    }
    public override void react(WinningManager gameState)
    {

        gameState.DebugLog.text = "Won";



       // gameState.winAnimation(); //
        // gameState.PlayMusic(); spiel musik ab 

        if (gameState.gameAnimationFinish == true)
        {
            gameState.switchState(gameState.Dead);
        }

        SceneManager.LoadScene("WinScreen");
        

    }
    public override void exit(WinningManager gameState)
    {

            // gamestate.musicstop
    }
}
