
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// collision hits -> animation starts 

public class Lvl0PlantState : WState  // collision animation state 
{
    public override void enter(WinningManager gameState)
    {
        Debug.Log("EnterAnimState");

    }
    public override void react(WinningManager gameState)
    {

        if (GameObject.FindGameObjectsWithTag("Leaf").Length == 0)
        {
            // play lvl basic plant 
            Debug.Log("0 Leafes left");
            gameState.switchState(gameState.Anim); // needs to define which anim // or anim will be already played idk 
            gameState.disableLeafUi();
        }
    }


    
    public override void exit(WinningManager gameState)
    {

        // gamestate.musicstop
    }
}








