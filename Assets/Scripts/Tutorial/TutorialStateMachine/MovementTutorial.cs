using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTutorial : TState
{
    public override void enter(TManager gameState)
    {

    }

    public override void react(TManager gameState)
    {
        if (gameState.wieIchBockHab == 9)
        {
            gameState.SwitchState(gameState.marvinONEState);
        }
    }

    public override void exit(TManager gameState)
    {

    }
}