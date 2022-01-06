using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Goo;
    public GameObject TestCollision;
    public GameObject Goal;
    private Cursor cursor;
    public GameObject Cursorr;
    public GameObject SteppingStone;
    [HideInInspector] //So it dose not clutter the inspector windo
    public bool StoneSpawned; //used in StoneManager//StoneStates to check if extra Stone alreasy Spawned
    private bool PlayAreaSpawned = false;
   
   
    // Start is called before the first frame update
    void Start()
    {
        //Get the Cursor in the beginning
        cursor = FindObjectOfType<Cursor>();
    }

    // Update is called once per frame
    void Update()
    {
        //if touche is detected take first touch
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            //check if Game Field is already spawned if not go on
            if (PlayAreaSpawned == false)
            {
                //Spawn differnt object on touche posiiton

                //Game Field
                GameObject obj = Instantiate(Goo, new Vector3(cursor.transform.position.x, cursor.transform.position.y, cursor.transform.position.z), cursor.transform.rotation);

                // Goal
                //GameObject bjo = Instantiate(Goal, new Vector3(cursor.transform.position.x, cursor.transform.position.y+0.2f, cursor.transform.position.z+0.7f), cursor.transform.rotation);

                //Collision T  Test Collison
                GameObject ojb = Instantiate(TestCollision, new Vector3(cursor.transform.position.x, cursor.transform.position.y+0.7f, cursor.transform.position.z), cursor.transform.rotation);
                

                //Set SpawnedTrue so only one set of enviroment can be spawned
                PlayAreaSpawned = true;
            }

        }
        //Moved to Better Neighbourhood :) (StoneManager)
        // void SpawnStone()
        // {
        //     //Spawn Stone prefab
        //     GameObject ojb = Instantiate(SteppingStone, new Vector3(cursor.transform.position.x, cursor.transform.position.y, cursor.transform.position.z)/*= new Vector3(cursor.transform.position.x, cursor.transform.position.y+0.5f, cursor.transform.position.z) */, cursor.transform.rotation); //locals above first spawned block(maybe some to the left on rope so i can fall;; also spawn rope )
        //     StoneSpawned = true;
        //     //-------------------Platform ?---------------------------------
        //     //spawns the rope now just needs to rotate and have block as child (can under child(1) (which is 2nd child cause 0=1) access cube and make rotations freeze //either let it spawn once or destroy after using 
        //     //GameObject job = Instantiate(platform, new Vector3(cursor.transform.position.x, cursor.transform.position.y + 0.9345f, cursor.transform.position.z), cursor.transform.rotation); 
        // }
    }
}
