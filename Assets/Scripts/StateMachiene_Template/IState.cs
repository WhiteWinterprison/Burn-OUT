using UnityEngine;
//--------TEMPLATE--------------------------
//-----NO Funktionalty so DONT USE----------
// ------------------------------------------
// This Manages that you can actually go threw a state
// NO OTHER CODE IN THIS THIS IS ALL IT NEEDS
// YOU CAN COPY IT LIKE IT IS 
// JUST CHANGE THE NAMES :
//IState = ThingyouDOingState
//RayCastManager = ThingyouDoinManager 
// ------------------------------------------

public abstract class IState
{
  public abstract void enter(RayCastManager gameState);
  public abstract void react(RayCastManager gameState);
  public abstract void exit(RayCastManager gameState);
}
