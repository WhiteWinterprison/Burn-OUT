using UnityEngine;

public abstract class IState // MUSS ABSTRACKTS CLASS SEIN !!!!  //IState umbennen ______State 
{
   public abstract void enter(RayCastManager gameState); //NameManager Script
   public abstract void react(RayCastManager gameState);
   public abstract void exit(RayCastManager gameState);
}
