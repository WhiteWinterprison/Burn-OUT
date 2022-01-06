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

    }
     public override void react (StoneManager gameState)
    {
       StonePlaced = gameState.IsStonePlaced;

       if( StonePlaced == true)
       {
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
        gameState.IsStonePlaced =false;
    }

    
}
