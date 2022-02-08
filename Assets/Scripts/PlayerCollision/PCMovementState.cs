using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovementState : PCState
{
    float time;
    public override void enter(PCManager gameState)
    {
        gameState.Debuglog.text = "Collision: Movement";
    }
    public override void react(PCManager gameState)
    {
         time += Time.deltaTime;
        float percentMoving = time/ gameState.startingTime;
        gameState.UiIndicator.color = Color.Lerp(Color.green,Color.black,percentMoving);

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
