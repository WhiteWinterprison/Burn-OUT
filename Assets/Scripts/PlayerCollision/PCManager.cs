using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
//code by: Marje & Isabel


public class PCManager : MonoBehaviour
{
    //---------UI-------
       public Text Debuglog;

    [SerializeField] Text Counter;
    [HideInInspector] public float currentTime = 0f;
    [HideInInspector] public float startingTime = 10f;
    public  Image UiIndicator;

    //--------Logic-------

    [HideInInspector] public bool pressedButton = false;

    [HideInInspector] public bool isDead;
    [HideInInspector] public bool isWinning;

    [HideInInspector ] public bool isSafe = false;

    [SerializeField]
    [Tooltip ("get Nr of Scene From Scene Manager")]
    private int EndGame;
    [Tooltip ("Pull in MainCamera von AR, Ray will start from here")]
    [SerializeField] private Camera Camera;

    //-------------------Winning------------------ 
    [Header ("Winning")] 
    #if UNITY_EDITOR
    [TextArea]
    public string developerDiscription= " Add all UI elements that should be setActive(false) when winning occures";
    #endif
    public GameObject[] UiParts = new GameObject [4];

    public GameObject[] UiWinParts = new GameObject[4];

    [HideInInspector] public StoneManager LeafManager;
    [HideInInspector] public LManager LvlManager;



    #region states 
    //-----------------------States-----------------------------
    PCState currentState;
    public PCDetectState DetectState = new PCDetectState();
    public PCMovementState MovementState = new PCMovementState();
    public PCGameOverState GameOverState = new PCGameOverState();
    public PCWinStat WinState = new PCWinStat();

    #endregion
    


    // Start is called before the first frame update
    void Start()
    {
        currentState = DetectState;
        currentState.enter(this);

        currentTime = startingTime;   

        GameObject StoneManager1 = GameObject.Find("StoneManager");    
        LeafManager = StoneManager1.GetComponent<StoneManager>();

        GameObject LevelManager = GameObject.Find("SceneManager");
        LvlManager = LevelManager.GetComponent<LManager>();

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


#region Collision //by marje //revisited because of collider issues
    // public void OnCollisionEnter(Collision collisioninfo)
    // {
    //     if (collisioninfo.collider.tag == "Stone") //maybe coroutine so player cant die when entering collision (think its bc it only on enter and then back to dying)
    //     {
    //         isSafe = true;

    //         Debuglog.text = "Stone";

    //     }


    //     if (collisioninfo.collider.tag == "Goo" && isSafe == false)
    //     {

    //         //SceneManager.LoadScene(EndGame);
    //         isDead = true;

    //         Debuglog.text = "Goo";
    //         //FindObjectOfType<GameManager>().EndGame();

    //     }
    // }

    // public void OnCollisionExit(Collision collisioninfo)
    // {
    //     if (collisioninfo.collider.tag == "Stone") //maybe coroutine so player cant die when entering collision (think its bc it only on enter and then back to dying)
    //     {
    //         isSafe = false;
    //     }

    //     //if (collisioninfo.collider.tag == "Goo")
    //     //{//if(Collision == "Goo") == dead
    //     //}
    // }
    #endregion


    public void ScreenPressed()
    {
        if (Input.touchCount > 1 && Input.touches[0].phase == TouchPhase.Moved)
        {
            pressedButton =true;
        }
    }

 //-----------------------------MoveTimer--------------------------

    public void PlayerTimer()
    {
        currentTime -= 1 * Time.deltaTime;
        Counter.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }
    }


  #region Raycast //by Isabel based on Logic von Marje collider

 //-----------------------------Raycast-----------------------------
    public void PlayerRaycastHit ()
    {
        RaycastHit hit; //check what you hit 
        Vector3 DirectionRay = Vector3.down;

        if(Physics.Raycast(Camera.transform.position, DirectionRay, out hit, 10)) //gives always out a bool
        {
            Debug.Log(hit.transform.name);
            Debug.DrawRay(Camera.transform.position, DirectionRay, Color.red, 10);
            
            if(hit.collider.CompareTag("Goo"))
            {
                isDead = true;
            } 
            else if (hit.collider.CompareTag("Finish"))
            {
                isWinning = true;
            }         
            
        }
    }
  #endregion
public void PlanAnimation()
{
   // LvlManager.spawnedOBJ.GetComponentInChildren<Animator>();
}
  
   

}
