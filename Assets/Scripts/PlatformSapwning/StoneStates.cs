using UnityEngine;

public abstract class StoneStates
{
    public abstract void enter(StoneManager gameState);
    public abstract void react(StoneManager gameState);
    public abstract void exit(StoneManager gameState);
}
