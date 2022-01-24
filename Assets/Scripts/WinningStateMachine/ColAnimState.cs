using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// collision hits -> animation starts 

public class ColAnimState : WState  // collision animation state 
{
    
    public override void enter(WinningManager gameState)
    {

    }
    public override void react(WinningManager gameState)
    {
        gameState.winAnimation(); //

       // gameState.PlayMusic(); spiel musik ab 

        if (gameState.gameAnimationFinish == true)
        {
            gameState.switchState(gameState.Dead);
        }

        

    }
    public override void exit(WinningManager gameState)
    {

            // gamestate.musicstop
    }
}
