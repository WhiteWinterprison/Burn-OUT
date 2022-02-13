using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTutorialState : TState
{
    public override void enter(TManager gameState)
    {
        gameState.playerInfo.SetActive(false);
        gameState.marvinMenu.SetActive(false);
        gameState.stoneSystem.SetActive(false);
        gameState.startGame.SetActive(false);
        gameState.cursorStart.SetActive(false);


        for (int i = 0; i < gameState.marvinExpr.Length; i++)
        {
            gameState.marvinExpr[i].SetActive(false);
        }
    }

    public override void react(TManager gameState)
    {
        if(gameState.tutorialStarted == true)
        {
            gameState.SwitchState(gameState.abyssState);
        } 
    }

    public override void exit(TManager gameState)
    {
        gameState.startTutorial.SetActive(false);
    }
}
