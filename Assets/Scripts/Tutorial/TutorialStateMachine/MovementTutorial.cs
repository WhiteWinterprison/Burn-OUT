using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorial : TState
{
    public override void enter(TManager gameState)
    {
        gameState.marvinExpr[1].SetActive(true);
        gameState.playerInfo.SetActive(true);
        gameState.DebugStatesExplained.text = "3";
    }

    public override void react(TManager gameState)
    {
        if (gameState.wieIchBockHab <=  9 && gameState.collisionManagereee.pressedButton == true)
        {
            gameState.SwitchState(gameState.marvinONEState);
        }
    }

    public override void exit(TManager gameState)
    {
        gameState.playerInfo.SetActive(false);
        gameState.marvinExpr[1].SetActive(false);
    }
}