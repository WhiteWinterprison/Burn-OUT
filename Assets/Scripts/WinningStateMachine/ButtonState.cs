
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


        // gameState.winAnimation();
        // if button is clicked true then switch state // works 
        if (gameState.ButtonPressed == true)
            {
            if (GameObject.FindGameObjectsWithTag("Leaf").Length == 3)
            {
                // play lvl 3 plant
                gameState.switchState(gameState.Lvl3);
                Debug.Log("3 Leafes left");
            }

            if (GameObject.FindGameObjectsWithTag("Leaf").Length == 2)
            {
                // play lvl 2 plant
                gameState.switchState(gameState.Lvl2);
                Debug.Log("2 Leafes left");
            }

            if (GameObject.FindGameObjectsWithTag("Leaf").Length == 1)
            {
                // play lvl 1 plant
                gameState.switchState(gameState.Lvl1);
                Debug.Log("1 Leafes left");
            }


            if (GameObject.FindGameObjectsWithTag("Leaf").Length == 0)
            {
                // play lvl basic plant 
                gameState.switchState(gameState.Lvl0);
                Debug.Log("0 Leafes left");
            }
        } 

    }
    public override void exit(WinningManager gameState)
    {

    }


}
