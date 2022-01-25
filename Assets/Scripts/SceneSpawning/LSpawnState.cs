using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSpawnState : LState //Level
{
    public override void enter(LManager gameState)
    {
        gameState.DisableCursor();
        gameState.DebugLog.text = "Spawned";
    }
    public override void react(LManager gameState)
    {

    }
    public override void exit(LManager gameState)
    {

    }
}
