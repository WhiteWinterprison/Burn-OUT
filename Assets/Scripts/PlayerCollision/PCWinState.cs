using UnityEngine;
using UnityEngine.SceneManagement;
using JXR.Utils;


public class PCWinState : PCState
{
    int LeafsLeft;

    public override void enter(PCManager gameState)
    {
        LeafsLeft = gameState.LeafManager.ButtonRemain;
        
        gameState.Score.Variable.SetValue(LeafsLeft); //scriptable object to use info in other scene
       
        //Set game play ui inactive
        for(int i=0; i < gameState.UiPartsGamePlay.Length ; i++)
        {
            gameState.UiPartsGamePlay[i].SetActive(false);
        }

        //set winn ui active 
        for(int i =0 ; i<gameState.UiWinPartsPhase1.Length; i++)
        {
            gameState.UiWinPartsPhase1[i].SetActive(true);
        }
        gameState.Debuglog.text = gameState.Score.Variable.value.ToString();

    }

    
    public override void react(PCManager gameState)
    {
        

        if(gameState.PlantButtonPressed == false)
        {
            return; //dont go further if button no press
        }
        

            if(LeafsLeft == 0)
            {
               // gameState.Debuglog.text = "0 leafs";
                gameState.LvlPlantAnimation("Score0","PlantAnim");        //Numbers can be rumoved to $"Score{LeafsLeft} = 0 in this case, as if you are in this state no leafs are left.      
            }
            else if (LeafsLeft == 1)
            {
                //gameState.Debuglog.text = "1 leafs";
                gameState.LvlPlantAnimation("Score1","PlantAnim");
            }
            else if (LeafsLeft == 2)
            {
               // gameState.Debuglog.text = "2 leafs";
                gameState.LvlPlantAnimation("Score2","PlantAnim");
            }
            else if (LeafsLeft == 3)
            {
               // gameState.Debuglog.text = "3 leafs";
                gameState.LvlPlantAnimation("Score3","PlantAnim");
            }

            
    
    }

    public override void exit(PCManager gameState)
    {
        
    }

}
