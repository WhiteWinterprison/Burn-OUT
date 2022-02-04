
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

        gameState.disableLeafUi();


        // eig kein loop notwendig da ich schon in der state bin wenn ich nur 3 blätter hab 
        // eig direkt gamestate.disableui(); und anim.play oder gamstate anim
        // play lvl 3 plant
        // play anim not switch state? would be better?

    }
    public override void exit(WinningManager gameState)
    {

        // gamestate.musicstop
    }
}







