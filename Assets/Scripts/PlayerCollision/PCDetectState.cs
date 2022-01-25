using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCDetectState : PCState
{
    public override void enter(PCManager gameState)
    {

    }
    public override void react(PCManager gameState)
    {
        

        
        if(gameState.pressedButton == true)
        {
            gameState.switchState(gameState.MovementState);
        }
        else if (gameState.isDead == true)
        {

            gameState.switchState(gameState.GameOverState);
        }
        

    }

   
    public override void exit(PCManager gameState)
    {

    }
}
