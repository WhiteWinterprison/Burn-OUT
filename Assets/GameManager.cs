using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    
    public float GameOverDelay = 2f;

    public GameObject CompleteLevelUI;

    public void CompleteLevel()
    {
        CompleteLevelUI.SetActive(true);
    }
    public void EndGame()
    {
        if (gameHasEnded == false) //to make the state game has ended only once (like debug.log only displaying a message once)
        {
            gameHasEnded = true;
            //Invoke("Restart", GameOverDelay);
            Restart();
        }
    }

    void Restart()
    {
        //dispay message to tap image tracking again or button to restart
        SceneManager.LoadScene("GameOver");
    }


}
