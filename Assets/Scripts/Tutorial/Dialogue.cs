using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue
{
    public string name;

    [TextArea(3, 10)] //first nr minimum amount of lines text area will use, sec max nr
    public string[] sentences;
}
