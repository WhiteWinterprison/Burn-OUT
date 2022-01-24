using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PCManager : MonoBehaviour
{
    public Button Bubble;

    [HideInInspector]
    public bool pressedButton = false;

    [SerializeField]
    public bool isDead;

    [SerializeField]
    public bool isSafe = true;

    [SerializeField]
    [Tooltip ("get Nr of Scene From Scene Manager")]
    private int EndGame;
    #region state
    //-----------------------States-----------------------------

    PCState currentState;
    public PCDetectState DetectState = new PCDetectState();
    public PCMovementState MovementState = new PCMovementState();
    public PCGameOverState GameOverState = new PCGameOverState();
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        currentState = DetectState;
        currentState.enter(this);

        Button btn = Bubble.GetComponent<Button>();
        btn.onClick.AddListener(buttonClicked);
    }

    // Update is called once per frame
    void Update()
    {
        currentState.react(this);
    }

    public void switchState(PCState nextState)
    {
        currentState.exit(this);
        currentState = nextState;
        nextState.enter(this);

    }

    //---------------------------------------------------------------------
    //------------------------Game Logic--------------------------------
    //---------------------------------------------------------------------

    public void OnCollisionEnter(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Stone") //maybe coroutine so player cant die when entering collision (think its bc it only on enter and then back to dying)
        {
            isSafe = true;
        }
       

        if (collisioninfo.collider.tag == "Goo" && isSafe == false)
        {

            //SceneManager.LoadScene(EndGame);
            isDead = true;
            //FindObjectOfType<GameManager>().EndGame();

        }
    }

    public void OnCollisionExit(Collision collisioninfo)
    {
        if (collisioninfo.collider.tag == "Stone") //maybe coroutine so player cant die when entering collision (think its bc it only on enter and then back to dying)
        {
            isSafe = false;
        }

        //if (collisioninfo.collider.tag == "Goo")
        //{//if(Collision == "Goo") == dead
        //}
    }

    public void buttonClicked()
    {
        pressedButton = true;
    }

}