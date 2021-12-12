using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Goo;
    public GameObject collisionT;
    private Cursor cursor;
    public GameObject Cursorr;
    public GameObject spawnStone;
    private bool hasSpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        cursor = FindObjectOfType<Cursor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            if (hasSpawned == false)
            {
                GameObject obj = Instantiate(Goo, new Vector3(cursor.transform.position.x, cursor.transform.position.y, cursor.transform.position.z), cursor.transform.rotation);
                GameObject ojb = Instantiate(collisionT, new Vector3(cursor.transform.position.x, cursor.transform.position.y+0.7f, cursor.transform.position.z), cursor.transform.rotation);
                Cursorr.SetActive(false);

                hasSpawned = true;
            }

            SpawnStone();
        }

        void SpawnStone()
        {
            GameObject ojb = Instantiate(spawnStone, new Vector3(cursor.transform.position.x, cursor.transform.position.y, cursor.transform.position.z)/*= new Vector3(cursor.transform.position.x, cursor.transform.position.y+0.5f, cursor.transform.position.z) */, cursor.transform.rotation); //locals above first spawned block(maybe some to the left on rope so i can fall;; also spawn rope )
                                                                                                                                                                                                                                                                                                   //GameObject job = Instantiate(platform, new Vector3(cursor.transform.position.x, cursor.transform.position.y + 0.9345f, cursor.transform.position.z), cursor.transform.rotation); //spawns the rope now just needs to rotate and have block as child (can under child(1) (which is 2nd child cause 0=1) access cube and make rotations freeze //either let it spawn once or destroy after using 
        }
    }
}
