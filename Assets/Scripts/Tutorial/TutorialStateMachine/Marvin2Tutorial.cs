using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marvin2Tutorial : TState
{
    public override void enter(TManager gameState)
    {

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

    }
}