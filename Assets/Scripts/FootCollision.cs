using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FootCollision : MonoBehaviour
{
    public imageTracking tracking; 
    bool canDie = false;
    [SerializeField]
    private int EndGame;

    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Stone") //maybe coroutine so player cant die when entering collision (think its bc it only on enter and then back to dying)
        {
            canDie = false;
        }
        //else
        //{
        //    canDie = true;
        //}

        if (collisioninfo.collider.tag == "Goo" && canDie == true)
        {
            tracking.enabled = false; //disable feet tracking to disable user movement (as game over logic)
            SceneManager.LoadScene(EndGame);
            //FindObjectOfType<GameManager>().EndGame();

        }
    }

    void OnCollisionExit(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Stone") //maybe coroutine so player cant die when entering collision (think its bc it only on enter and then back to dying)
        {
            canDie = true;
        }

        if (collisioninfo.collider.tag == "Goo")
        {

            //FindObjectOfType<GameManager>().EndGame();

        }
    }
}

