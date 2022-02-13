using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTutorialState : TState
{
    public override void enter(TManager gameState)
    {
        gameState.DebugStatesExplained.text = "LeafTutorial";
    }

    public override void react(TManager gameState)
    {
        if(gameState.wieIchBockHab == 17)
        {
            gameState.SwitchState(gameState.movementState);
        }
    }

    public override void exit(TManager gameState)
    {

    }
}