using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LIdleState : LState
{

    bool stuffHappened;

    public override void enter(LManager gameState)
    {
        gameState.EnableCursor();
        gameState.DebugLog.text = "DebugText.Idle";
        //gameState.DebugLog.text = stuffHappened.ToString();
    }
    public override void react(LManager gameState)
    {
        gameState.Spawner();

        if (gameState.PlayAreaSpawned == true)
        {
            gameState.switchState(gameState.SpawnState); //comes at the very last cause why would you switch the state when still wanting to do something
        }
       
    }
    public override void exit(LManager gameState)
    {
       // gameState.Yes();
    }
}
