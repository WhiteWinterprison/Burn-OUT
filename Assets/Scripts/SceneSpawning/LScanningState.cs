using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LScanningState : LState
{
    private Cursor CursorScript;
     public override void enter (LManager gameState)
    {
        //gameState.DisableCursor();
        
        //getting Variable from Curser
        GameObject theCursor =GameObject.Find("SpawnCursor");
        CursorScript = theCursor.GetComponent<Cursor>();   

        
    }
     public override void react (LManager gameState)
    {
        gameState.DebugLog.text = "LvlSpawnScnaning: " + CursorScript.FloorIsFound.ToString();

        if(CursorScript.FloorIsFound == true)
       {
           gameState.switchState(gameState.IdleState);
       }
    }
     public override void exit (LManager gameState)
    {
       
    }
}
