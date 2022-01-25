using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCDetectState : PCState
{
    public override void enter(PCManager gameState)
    {
        gameState.Debuglog.text = "Detected";
    }
    public override void react(PCManager gameState)
    {
        

        
        if(gameState.pressedButton == true)
        {
            gameState.switchState(gameState.MovementState);
            Debug.Log("kkeoroierueiweesfsyd<fhiouywjior");

        }
        else if (gameState.isDead == true)
        {

            gameState.switchState(gameState.GameOverState);

            gameState.Debuglog.text = "you ded";
        }
        

    }

   
    public override void exit(PCManager gameState)
    {

    }
}
