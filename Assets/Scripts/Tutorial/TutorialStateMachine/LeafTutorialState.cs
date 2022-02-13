using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafTutorialState : TState
{
    public override void enter(TManager gameState)
    {

        gameState.marvinExpr[0].SetActive(true);

        gameState.DebugStatesExplained.text = "LeafTutorial";

        gameState.stoneSystem.SetActive(true);
    }

    public override void react(TManager gameState)
    {


        if(gameState.wieIchBockHab == 17 && gameState.Score < 3)
        {
            gameState.SwitchState(gameState.movementState);
        }


    }

    public override void exit(TManager gameState)
    {
        gameState.stoneSystem.SetActive(false);
        gameState.marvinExpr[0].SetActive(false);
    }
}