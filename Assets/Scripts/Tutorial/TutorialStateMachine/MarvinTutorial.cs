using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarvinTutorial : TState
{
    public override void enter(TManager gameState)
    {
        gameState.marvinMenu.SetActive(true);
        gameState.slideMenu.ShowHideMenue();
        gameState.marvinExpr[0].SetActive(true);
        gameState.DebugStatesExplained.text = "3";
        gameState.QueCounter.text = gameState.wieIchBockHab.ToString(); 
    }

    public override void react(TManager gameState)
    {
        if (gameState.wieIchBockHab <=  7)
        {
            gameState.SwitchState(gameState.marvinTWOState);
        }
    }

    public override void exit(TManager gameState)
    {
        gameState.marvinExpr[0].SetActive(false);
    }
}
