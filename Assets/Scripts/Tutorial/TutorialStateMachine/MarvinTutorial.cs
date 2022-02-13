using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarvinTutorial : TState
{
    public override void enter(TManager gameState)
    {

    }

    public override void react(TManager gameState)
    {
        if (gameState.wieIchBockHab == 7)
        {
            gameState.SwitchState(gameState.marvinTWOState);
        }
    }

    public override void exit(TManager gameState)
    {

    }
}
