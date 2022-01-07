using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoneManager : MonoBehaviour
{
    #region Variables 
    [Space]
     [SerializeField]
    public  GameObject Cursor;

    [Space]
    [Header("ButtonRemain & Image Array Size need to be the")]
    [Header ("---Buttons---")]
    public Button LeafButton;
    [HideInInspector]
    public bool ButtonPressed = false; //does this work ??
    
    public int ButtonRemain = 3;
    [SerializeField]
    Image[] images = new Image[3];

    private Spawner m_ObjectSpawner;

    public  Text DebugLOG;

    [Header ("Stone Placement")]
    private Cursor cursor;
    public GameObject SteppingStone;
    [HideInInspector] 
    public bool IsStonePlaced; 
     public GameObject ojb;

    #endregion

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

        currentState = StoneIdle;
        currentState.enter(this);

        //--------------Button--------------
        Button btn = LeafButton.GetComponent<Button>();
        btn.onClick.AddListener(ButtonClicked);   //Code variant anstatt code zum button Inspector      
        cursor = FindObjectOfType<Cursor>();  

        IsStonePlaced = false;

    }
    void Update()
    {
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
                Object ojb = Instantiate(SteppingStone, new Vector3(cursor.transform.position.x, cursor.transform.position.y, cursor.transform.position.z), cursor.transform.rotation); //locals above first spawned block(maybe some to the left on rope so i can fall;; also spawn rope )
                IsStonePlaced = true;
                DebugLOG.text ="Is Spawned";
                //-------------------Platform ?---------------------------------
                //spawns the rope now just needs to rotate and have block as child (can under child(1) (which is 2nd child cause 0=1) access cube and make rotations freeze //either let it spawn once or destroy after using 
                //GameObject job = Instantiate(platform, new Vector3(cursor.transform.position.x, cursor.transform.position.y + 0.9345f, cursor.transform.position.z), cursor.transform.rotation); 
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
