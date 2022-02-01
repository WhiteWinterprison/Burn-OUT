using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Idle State before Collision hits (while game is palying= idle)
public class WinIdleState : WState
{

    public override void enter(WinningManager gameState)
    {
        // hier kommt alles rein was gemacht werden muss bevor es beginnt 
        Debug.Log("EnterIdleState");
    }
    public override void react(WinningManager gameState)  // wann man phase wechseln soll  // ruft fkt auf die passieren soll wenn man in der state ist zb musik bis szene geswitched wird
    { // if collision = true then switch 

        if (gameState.gameCollision == true)
        {
            gameState.switchState(gameState.Button);
           // Debug.Log("Collision is true");
        }
    }
    public override void exit(WinningManager gameState)
    {
        // alles was man haben will bevor die nächste szene geladen wird zb musik stoppen oder grafik ausblenden 
    } 

}
