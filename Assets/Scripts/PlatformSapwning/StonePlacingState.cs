using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StonePlacingState : StoneStates
{
    private bool StonePlaced;
    

    public override void enter (StoneManager gameState)
    {
        //enable Cursor Once
        gameState.EnableCursor();
        StonePlaced = false;  
        gameState.DebugLOG.text = "Platform Log:Placing";

    }
     public override void react (StoneManager gameState)
    {
        
         gameState.SpawnStone();
    
    
    //    StonePlaced = gameState.IsStonePlaced;

       if( gameState.IsStonePlaced == true) //If a stone is placed we go into the switch statement
       {
           gameState.DebugLOG.text = "Platform Log:StonePlaced";

            if(gameState.ButtonRemain <= 0)
            {
                //No stones left go to dead
                gameState.switchState(gameState.StoneDead);
            }
            else
            {
                gameState.LeafButton.GetComponent<Button>().interactable =true;
                //When Stones left go back to Idle
                gameState.switchState(gameState.StoneIdle);
                
            }
       }
    }        
     public override void exit (StoneManager gameState)
    {
        //Disable Cursor once
        gameState.DisableCursor();
        //Importatn so only one plant spawns in each itteration
        gameState.IsStonePlaced =false;

        gameState.ButtonPressed =false;
        //Waiting time, makes stuff smoother 
        gameState.DebugLOG.text = "Waiting for Change";
        gameState.Waiting();

    }

    
}
