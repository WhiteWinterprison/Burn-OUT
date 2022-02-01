
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// collision hits -> animation starts 

public class AnimatorState : WState  // collision animation state 
{


    public override void enter(WinningManager gameState)
    {
        Debug.Log("EnterAnimState");


    }
    public override void react(WinningManager gameState)
    {

        //anim.Play("IsBigger");


        // gameState.winAnimation(); //
        // gameState.PlayMusic(); spiel musik ab 

        if (gameState.gameAnimationFinish == true)    // für später wenn anim fertig abgespielt ist 
        {
            gameState.switchState(gameState.Dead);

        }



    }
    public override void exit(WinningManager gameState)
    {

        // gamestate.musicstop
    }
}






