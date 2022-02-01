using System.Collections;
using System.Collections.Generic;

using UnityEngine;

/// <summary>
/// state für opening book am ende gatcha 
/// </summary>

public class DeadState : WState
{
    public override void enter(WinningManager gameState)
    {

    }
    public override void react(WinningManager gameState)
    {
        // gameState.switchState(gameState.ColAnimState);  end state
        // scene zu wingame 
      //  gameState.LoadScene();

    }
    public override void exit(WinningManager gameState)
    {

    }

 
}
