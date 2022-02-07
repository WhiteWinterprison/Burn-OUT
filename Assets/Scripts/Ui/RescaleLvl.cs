using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescaleLvl : MonoBehaviour
{
     
     private LManager Lvlmanager;
     private StoneManager SteppingStones;

     //private Cursor LeafCursor;
     private GameObject LeafCursor;
    public Text DebugLOG;
    private Vector3  offest = new Vector3(0,0.5f,0);    
    private Vector3 size = new Vector3(1,1,1);

  void Start()
  {
      //Getting The gameObject Componentes 

        GameObject Stones = GameObject.Find("StoneManager");
        SteppingStones = Stones.GetComponent<StoneManager>();


        GameObject LevelManager = GameObject.Find("SceneManager");
        Lvlmanager = LevelManager.GetComponent<LManager>();

        GameObject CursorManager = GameObject.Find("LeafCursor");
        LeafCursor = GameObject.Find("LeafIcon");

  }
    public void MoveUp ()
    {
        Lvlmanager.spawnedOBJ.gameObject.transform.position += offest; 
      //Lvlmanager.spawnedOBJ.gameObject.transform.localScale +=size;

      //Get current positionl values
        float LeafX = SteppingStones.SpawnedObject.gameObject.transform.position.x;
        float LeafZ = SteppingStones.SpawnedObject.gameObject.transform.position.z;
        float LevelY = Lvlmanager.spawnedOBJ.gameObject.transform.position.y;
      
      
      //move leaves
        for(int i=0 ; i <3 ; i++ )
        {
            SteppingStones.InstantiatedLeafs[i].gameObject.transform.position += offest;
        }

      //Vector3 LeafPosition = new Vector3(LeafX,LevelY,LeafZ);
      //SteppingStones.SpawnedObject.gameObject.transform.position = LeafPosition; 

      //move LeafSpwanCursor
      LeafCursor.transform.position += offest;
    }

    public void MoveDown()
    {
        DebugLOG.text ="movedown";
        //Move Lvl
        Lvlmanager.spawnedOBJ.gameObject.transform.position -= offest; 
        //Lvlmanager.spawnedOBJ.gameObject.transform.localScale +=size; //resize lvl for move

    //Get current positionl values
        float LeafX = SteppingStones.SpawnedObject.gameObject.transform.position.x;
        float LeafZ = SteppingStones.SpawnedObject.gameObject.transform.position.z;
        float LevelY = Lvlmanager.spawnedOBJ.gameObject.transform.position.y;
     
    //move leaves
     
      for(int i=0 ; i <3 ; i++ )
        {
            SteppingStones.InstantiatedLeafs[i].gameObject.transform.position -= offest;
        }

       //Vector3 LeafPosition = new Vector3(LeafX,LevelY,LeafZ);
      //SteppingStones.SpawnedObject.gameObject.transform.position = LeafPosition; 

       //move LeafSpwanCursor
      LeafCursor.transform.position -= offest;
    }

    //-----------------------Already tried stuff for leaf movement----------------------
    // SteppingStones.SpawnedObject.gameObject.transform.position -= offest;
    // SteppingStones.SpawnedObject.gameObject.transform.position = Lvlmanager.spawnedOBJ.gameObject.transform.position; 
    // SteppingStones.SpawnedObject.gameObject.transform.position.Set(0,Lvlmanager.spawnedOBJ.gameObject.transform.position.y,0); 

}
