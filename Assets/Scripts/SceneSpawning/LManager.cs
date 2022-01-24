using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LManager : MonoBehaviour //Level
{
    //------------------------Variablen------------------------
    public bool Fun;
    public Text DebugLog;
    //------------------------States------------------------
    LState currentState;
    public LIdleState IdleState = new LIdleState();
    public LSpawnState SpawnState = new LSpawnState();

    //------------------------Spawn------------------------
    public GameObject Level;

    [SerializeField]
    private GameObject cursor;
    //public GameObject Cursorr;
    [HideInInspector]
    public bool PlayAreaSpawned = false;


    // Start is called before the first frame update
    void Start()
    {
        currentState = IdleState;
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
            DebugLog.text = "Touched";

            //Game Field

            GameObject obj = Instantiate(Level, cursor.transform.position, cursor.transform.rotation);

            DebugLog.text = "Spawned";
            //Set SpawnedTrue so only one set of enviroment can be spawned
            PlayAreaSpawned = true;

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
}
