using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssTutorialState : TState
{
    

    public override void enter(TManager gameState)
    {
        gameState.marvinExpr[2].SetActive(true);
        //gameState.cursorStart.SetActive(true);

        //gameState.DebugStatesExplained.text = "QueueInfo: " + gameState.queueInfo.sentences.Count.ToString();
    }

    public override void react(TManager gameState)
    {
        if(gameState.levelInfo.PlayAreaSpawned == true && gameState.wieIchBockHab == 21)
        {
            gameState.SwitchState(gameState.leafState);
        }
    }

    public override void exit(TManager gameState)
    {
        gameState.marvinExpr[2].SetActive(false);
    }
}
