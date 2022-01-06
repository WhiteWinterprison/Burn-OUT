using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class StoneIdleState : StoneStates
{
    public override void enter (StoneManager gameState)
    {

    }
     public override void react (StoneManager gameState)
    {
        if(gameState.ButtonPressed == true)
        {
            gameState.switchState(gameState.StonePlacing);
        }
    }
     public override void exit (StoneManager gameState)
    {
        //Button wird nicht mehr gedrückt
        gameState.ButtonPressed =false;
        //Button funktion Disable still be shown
        gameState.LeafButton.GetComponent<Button>().interactable =false;
    }

    
}
