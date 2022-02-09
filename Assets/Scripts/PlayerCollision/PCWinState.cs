using UnityEngine;
using UnityEngine.SceneManagement;

public class PCWinStat : PCState
{
    int LeafsLeft;

    public override void enter(PCManager gameState)
    {
        // gameState.Debuglog.text = "Collision: You Won";
        //Set game play ui inactive
        for(int i=0; i < gameState.UiParts.Length ; i++)
        {
            gameState.UiParts[i].SetActive(false);
        }

        //set winn ui active 
        for(int i =0 ; i<gameState.UiWinParts.Length; i++)
        {
            gameState.UiWinParts[i].SetActive(true);
        }

    }

    
    public override void react(PCManager gameState)
    {
        LeafsLeft = gameState.LeafManager.ButtonRemain;

    //    if(LeafsLeft == 0)
    //    {
    //        gameState.Debuglog.text = "0 leafs";
    //    }
    //    else if (LeafsLeft == 1)
    //    {
    //        gameState.Debuglog.text = "1 leafs";
    //    }
    //    else if (LeafsLeft == 2)
    //    {
    //        gameState.Debuglog.text = "2 leafs";
    //    }
    //    else if (LeafsLeft == 3)
    //    {
    //        gameState.Debuglog.text = "3 leafs";
    //    }
    }

    public override void exit(PCManager gameState)
    {
        
    }

}
