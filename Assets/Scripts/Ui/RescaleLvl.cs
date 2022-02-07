using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RescaleLvl : MonoBehaviour
{
     
     private LManager Lvlmanager;
     private StoneManager SteppingStones;
    public Text DebugLOG;
    private Vector3  offest = new Vector3(0,1,0);
    private Vector3 size = new Vector3(1,1,1);




  void Start()
  {
      //Getting The gameObject Componentes 

        GameObject Stones = GameObject.Find("StoneManager");
        SteppingStones = Stones.GetComponent<StoneManager>();

        GameObject LevelManager = GameObject.Find("SceneManager");
        Lvlmanager = LevelManager.GetComponent<LManager>();

  }
    public void MoveUp ()
    {
        Lvlmanager.spawnedOBJ.gameObject.transform.position += offest; 
      //Lvlmanager.spawnedOBJ.gameObject.transform.localScale +=size;

      //move leaves
      //SteppingStones.SpawnedObject.gameObject.transform.position += offest;
      
      SteppingStones.SpawnedObject.gameObject.transform.position = Lvlmanager.spawnedOBJ.gameObject.transform.position + offest; 


    }

    public void MoveDown()
    {
        DebugLOG.text ="movedown";

        Lvlmanager.spawnedOBJ.gameObject.transform.position -= offest; 
      //Lvlmanager.spawnedOBJ.gameObject.transform.localScale +=size;
      //SteppingStones.SpawnedObject.gameObject.transform.position -= offest;
      SteppingStones.SpawnedObject.gameObject.transform.position = Lvlmanager.spawnedOBJ.gameObject.transform.position - offest; 

    }


}
