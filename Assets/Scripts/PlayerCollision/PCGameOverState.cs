using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PCGameOverState : PCState
{
    public override void enter(PCManager gameState)
    {
        gameState.Debuglog.text = "you ded ded";

    }
    public override void react(PCManager gameState)
    {
        SceneManager.LoadScene("GameOver");

    }
    public override void exit(PCManager gameState)
    {

    }
}
