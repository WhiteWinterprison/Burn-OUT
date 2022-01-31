using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LState //Level
{

    public abstract void enter(LManager gameState);
    public abstract void react(LManager gameState);
    public abstract void exit(LManager gameState);

}
