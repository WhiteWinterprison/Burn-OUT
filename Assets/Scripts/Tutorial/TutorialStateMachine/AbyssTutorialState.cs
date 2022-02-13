using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssTutorialState : TState
{
    

    public override void enter(TManager gameState)
    {
        gameState.marvinExpr[0].SetActive(true);
        gameState.cursorStart.SetActive(true);
    }

    public override void react(TManager gameState)
    {
        if(gameState.levelInfo.PlayAreaSpawned == true)
        {
            gameState.SwitchState(gameState.leafState);
        }
    }

    public override void exit(TManager gameState)
    {

    }
}
