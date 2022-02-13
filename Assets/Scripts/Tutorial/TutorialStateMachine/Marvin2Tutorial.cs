using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marvin2Tutorial : TState
{
    public override void enter(TManager gameState)
    {
        gameState.marvinExpr[2].SetActive(true);
    }

    public override void react(TManager gameState)
    {
        if (gameState.wieIchBockHab == 0)
        {
            gameState.SwitchState(gameState.startGameState);
        }
    }

    public override void exit(TManager gameState)
    {
        gameState.playerInfo.SetActive(false);
        gameState.marvinMenu.SetActive(false);
        gameState.stoneSystem.SetActive(false);
        gameState.startGame.SetActive(false);
        gameState.marvinExpr[2].SetActive(false);
    }
}