using UnityEngine;

//--------TEMPLATE--------------------------
//-----NO Funktionalty so DONT USE----------
// ------------------------------------------
// Template how to set up a Game state. 
// A State Machine can have as many as wanted in Game states. 
// you just need those 3 Funktion wich works as Void start & Update & LAte Update basically
// ------------------------------------------

public class GameStartedState : IState 
{
   public override void enter(RayCastManager gameState)
   {
        //Will be called when entering the starte like start
   }

   public override void react(RayCastManager gameState)
   {
        //will be called like Update
   }

   public override void exit(RayCastManager gameState)
   {
        //This will be called when leaving the state 
   }
}
