using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PCState //PlayerCollision State
{
     public abstract void enter(PCManager gameState); //NameManager Script
     public abstract void react(PCManager gameState);
     public abstract void exit(PCManager gameState);
}
