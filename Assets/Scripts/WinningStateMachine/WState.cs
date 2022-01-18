using UnityEngine;

public abstract class WState
{
    public abstract void enter(WinningManager gameState);
    public abstract void react(WinningManager gameState);
    public abstract void exit(WinningManager gameState);
}

