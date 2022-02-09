using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCMovementState : PCState
{
    float time = 0;    
    float startingTime1;

    public override void enter(PCManager gameState)
    {
        gameState.Debuglog.text = "Collision: Movement";
        gameState.currentTime =  gameState.startingTime; 
    }

    public override void react(PCManager gameState)
    {
         time += Time.deltaTime;
        float percentMoving = time/ gameState.startingTime;

        gameState.UiIndicator.color = Color.Lerp(Color.green,Color.black, percentMoving);

        gameState.PlayerTimer();
        gameState.Debuglog.text = "Collision: "+percentMoving.ToString();

       if(gameState.currentTime == 0)
        {
             time = 0 ;
            gameState.switchState(gameState.DetectState);
        }

    }
    public override void exit(PCManager gameState)
    {
       
        gameState.pressedButton = false;
    }
}
