using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameState : TState
{
    public override void enter(TManager gameState)
    {
        gameState.startGame.SetActive(true);
        gameState.marvinExpr[4].SetActive(true);
        gameState.DebugStatesExplained.text = "6";
        gameState.QueCounter.text = gameState.wieIchBockHab.ToString(); 
    }

    public override void react(TManager gameState)
    {
        if (gameState.gameStarted == true) //might as well just leave the ==
        {
            SceneManager.LoadScene(5);
        }
    }

    public override void exit(TManager gameState)
    {

    }
}