using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//--------TEMPLATE--------------------------
//-----NO Funktionalty so DONT USE----------
// ------------------------------------------
//This is wher you will call your state && load new states 

public class RayCastManager : MonoBehaviour
{
   // Start is called before the first frame update
    
   IState currentState;

   #region GameSates
   //Do this with ALL YOUR STATES so you can use them
  public GameStartedState GameStarted = new GameStartedState();
   
  #endregion
   void Start()
   {
        
   }

   // Update is called once per frame
   void Update()
   {
        
   }
}
