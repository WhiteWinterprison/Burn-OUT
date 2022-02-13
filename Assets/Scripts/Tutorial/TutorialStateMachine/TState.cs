using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TState 
{
    public abstract void enter(TManager gameState); //NameManager Script
    public abstract void react(TManager gameState);
    public abstract void exit(TManager gameState);
}
