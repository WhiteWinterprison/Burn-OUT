using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollision : MonoBehaviour
{
    public imageTracking tracking;
    bool canDie = false;

    void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Stone") //maybe coroutine so player cant die when entering collision (think its bc it only on enter and then back to dying)
        {
            canDie = false;
        }
        else
        {
            canDie = true;
        }

        if (collisioninfo.collider.tag == "Goo" && canDie == true)
        {
            tracking.enabled = false;
            FindObjectOfType<GameManager>().EndGame();

        }
    }
}
