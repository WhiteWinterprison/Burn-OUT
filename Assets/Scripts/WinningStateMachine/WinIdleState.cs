using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinIdleState : WState
{

    public override void enter(WinningManager gameState)
    {
        // if colllider = true 
        
    }
    public override void react(WinningManager gameState)
    {
        gameState.switchState(gameState.ColAnimState);
    }
    public override void exit(WinningManager gameState)
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }





}
