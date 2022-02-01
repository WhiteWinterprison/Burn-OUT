using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovementState : PCState
{
    public override void enter(PCManager gameState)
    {
        gameState.Debuglog.text = "MoveIt";
    }
    public override void react(PCManager gameState)
    {
        gameState.PlayerTimer();

       if(gameState.currentTime == 0)
        {
            gameState.switchState(gameState.DetectState);
            
        }

    }
    public override void exit(PCManager gameState)
    {
        gameState.currentTime = 10;
        gameState.pressedButton = false;
    }
}
