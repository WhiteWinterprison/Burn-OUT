using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class LManager : MonoBehaviour //Level
{
    //------------------------Variablen------------------------
    public Text DebugLog;
    //------------------------States------------------------
    LState currentState;
    
    public LScanningState ScanningState = new LScanningState();
    public LIdleState IdleState = new LIdleState();
    public LSpawnState SpawnState = new LSpawnState();

    //------------------------Spawn------------------------
    public GameObject Level;
    [SerializeField]   private GameObject cursor;
    //public GameObject Cursorr;
    [HideInInspector]  public bool PlayAreaSpawned = false;
    [HideInInspector] public  GameObject spawnedOBJ; //need to be public so i can use it in RescaleLvl

    // //----------------------MoveScene----------------------
    // private Vector3  offest = new Vector3(0,1,0);
    // private Vector3 size = new Vector3(1,1,1);
    // public Text UpDown ;


    // Start is called before the first frame update
    void Start()
    {
        currentState = ScanningState;
        currentState.enter(this);

        //cursor = FindObjectOfType<GameObject>();

    }

    // Update is called once per frame
    void Update()
    {
        currentState.react(this);
    }

    public void switchState(LState nextState)
    {
        currentState.exit(this);
        currentState = nextState;
        nextState.enter(this);

    }

    public void Spawner() //manages what is spawned when
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            //check if Game Field is already spawned if not go on
            DebugLog.text = "LvlSpawn: Touched";

            //Game Field

            spawnedOBJ = Instantiate(Level, cursor.transform.position, cursor.transform.rotation);

            AbysallAniamtion();
            DebugLog.text = "LvlSpawn: Spawned";
            //Set SpawnedTrue so only one set of enviroment can be spawned

        }
    }

    public void EnableCursor()
    {
        cursor.SetActive(true);
    }
    public void DisableCursor()
    {
        cursor.SetActive(false);
    }

    //   public void MoveUp ()
    // {
    //     UpDown.text ="moveUp";
    //     spawnedOBJ.gameObject.transform.position += offest;       
    //    // spawnedOBJ.gameObject.transform.localScale -=size;   //to make the size still fitting for the hight (doesn really work though)
    // }

    //    public void MoveDown()
    // {
    //     spawnedOBJ.gameObject.transform.position -= offest; 
    //    // spawnedOBJ.gameObject.transform.localScale +=size;
    // }

    public void AbysallAniamtion()
    {
        Animator animator = spawnedOBJ.GetComponent<Animator>();
            DebugLog.text="NOANIMATORFOUND";
        if(animator != null)
        {
            DebugLog.text="Found";
            bool isOpening = animator.GetBool("IsSpawned");
            animator.SetBool("IsSpawned",true); 
            if(animator.GetBool("IsSpawned")== true)
            {
                PlayAreaSpawned = true;
            }
        }
    }
      
    
}
