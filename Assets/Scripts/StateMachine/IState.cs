using UnityEngine;

public abstract class IState
{
   public abstract void enter(SpawnObject gameState);
   public abstract void react(SpawnObject gameState);
   public abstract void exit(SpawnObject gameState);
}
