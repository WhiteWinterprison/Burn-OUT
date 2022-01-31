using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class StoneManager : MonoBehaviour
{
    #region Variables 
    [Space]
    //------------------------Curosr------------------------
    public  GameObject Cursor;
    
    //------------------------Buttons------------------------
    [Space]
    [Header("ButtonRemain & Image Array Size need to be the")]
    [Header ("---Buttons---")]
    public Button LeafButton;
    [HideInInspector]
    public bool ButtonPressed = false; //does this work ??
    
    public int ButtonRemain = 3;
    [SerializeField]
    [Tooltip ("The UI leafs Drag and Drop")]
    Image[] images = new Image[3]; 

    //------------------------Spawn------------------------

    [Header ("Stone Placement")]
    private Cursor cursor;
    public GameObject SteppingStone;
    [HideInInspector] 
    public bool IsStonePlaced; 

    #endregion

    //------------------------Debug----------------------
    public  Text DebugLOG;
    
    //------------------------States---------------------
    StoneStates currentState;
    
    public  StonePlacingState StonePlacing = new StonePlacingState();
    public StoneIdleState  StoneIdle = new StoneIdleState();
    public StoneDeadState StoneDead = new StoneDeadState();

//-------------------State Machine-----------------------------------------
//------------------------------------------------------------------------
    void Start()
    {
        //DebugLOG
        DebugLOG.text = "DebugLOG: ";

        currentState = StoneIdle; //erste state der aufgerufen werden soll
        currentState.enter(this);

        //--------------Button--------------
        Button btn = LeafButton.GetComponent<Button>();
        btn.onClick.AddListener(ButtonClicked);   //Code variant anstatt code zum button Inspector      
        cursor = FindObjectOfType<Cursor>();  

        IsStonePlaced = false;

    }
    void Update()
    {
        //Nur diesn script im Update. 
        currentState.react(this);
       
    }


    public void switchState(StoneStates nextState)
    {
        currentState.exit(this);
        currentState = nextState ;
        nextState.enter(this);
    }


#region GameLogic
//--------------------------------------------------------------------------------------------------------
//-------------------------------- Game Logic ------------------------------------------------------------
//----------------------Logic for the Whole thingy gose here----------------------------------------------

//Button Pressed
    public void ButtonClicked()
    {
        //reduce Button energy
        ButtonRemain -= 1 ;
        DebugLOG.text = "ButtonReamin:" + ButtonRemain.ToString();
        //Disable 1 Leaf Icon
        images[ButtonRemain].enabled = false; //2 verschwinden

        ButtonPressed = true;
    }
    public void EnableCursor()
//Curoser will be shown && Can be Used
    {
            Cursor.SetActive(true);
    }
    public void DisableCursor()
    {
        Cursor.SetActive(false);
    }

//Placing Object

        public void SpawnStone()
        {
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began && IsStonePlaced == false) //only spawn something if I touched && if IsStonePlaced is false
            {
                DebugLOG.text = "Touched";
                //Spawn Stone prefab
                GameObject SpawnedObject = Instantiate(SteppingStone, Cursor.transform.position, Cursor.transform.rotation);

                IsStonePlaced = true;
                DebugLOG.text ="Is Spawned";

            }
        }

//waiting
        public IEnumerator Waiting()
        {
            yield return new WaitForSeconds(2);
        }

//Debug Code


//--------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------
//--------------------------------------------------------------------------------------------------------
#endregion
}
