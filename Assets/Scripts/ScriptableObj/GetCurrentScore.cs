using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JXR.Utils; //Jesco <3

public class GetCurrentScore : MonoBehaviour
{
        //     ----------xample-----------
        //   public IntReference myIntReference;
        //   public IntReference myOtherIntRef;
    private void Start()
    {
        // //set Value
        // myIntReference.Variable.SetValue(10);

        // //get Value
        // myLocalInt = myIntReference;
    }

    //The IntReference can be either "Constatn" or a Variable" Choose in inspector tab
    //When it is a consant it behaves like a normal int and wont be saved outside the scene
    //When it is a variable move a SCriptable object from the Projekt folder into the inspector
    //The value then read & write from that scriptable object in folder
    //the value will stay there even on scene change :3
}
