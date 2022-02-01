
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// Button state 
/// Button pressed need to be shown 
/// remover all other game ui 
/// button pressed make plant grow 

public class ButtonState : WState
{
    public override void enter(WinningManager gameState)
    {
        Debug.Log("EnterButtonState");
        gameState.disableGameUi();



    }
    public override void react(WinningManager gameState)
    {
        gameState.enableButton();
        gameState.DebugLog.text = "Won";


        // if button is clicked true then switch state // works 
           if (gameState.ButtonPressed == true)
            {
                gameState.switchState(gameState.Anim);

            } 

    }
    public override void exit(WinningManager gameState)
    {

    }


}
