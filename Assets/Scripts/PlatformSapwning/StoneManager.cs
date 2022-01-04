using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StoneManager : MonoBehaviour
{
    StoneStates currentState;
    
    public  StonePlacingState StonePlacing = new StonePlacingState();
    public StoneIdleState StoneIdle = new StoneIdleState();
    public StonePlacedState StonePlaced = new StonePlacedState();


    void Start()
    {

    }
    void Update()
    {

    }
}
