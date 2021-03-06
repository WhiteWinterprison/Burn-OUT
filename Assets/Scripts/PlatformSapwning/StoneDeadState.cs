using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//REUSE TO DEAD STATE
//USE WHEN NO STONES LEF
//SAD
public class StoneDeadState: StoneStates
{
  public override void enter (StoneManager gameState)
  {
    gameState.DebugLOG.text = "Platform Log: No Stones";
  }
 public override void react (StoneManager gameState)
 {
   if(gameState.ButtonRemain > 0)
   {
     
      gameState.switchState(gameState.StoneIdle);
   }
 }
  public override void exit (StoneManager gameState)
  {
     gameState.LeafButton.GetComponent<Button>().interactable =true;
     gameState.DebugLOG.text = "Waiting for Change";
     gameState.Waiting();
  }  
    
}
