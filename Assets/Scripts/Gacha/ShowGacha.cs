using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using JXR.Utils;

public class ShowGacha : MonoBehaviour
{
    public Text DebugLog;
    public IntReference Score;
    
    public GameObject[] LockedIcons = new GameObject[4];

    void Awake()
    {
        DebugLog.text ="lkjsefseo"+Score.Variable.value.ToString();
        for(int i= 0; i< LockedIcons.Length; i++)
        {
            LockedIcons[Score.value].SetActive(true);
        }
    }

    void Start(){

    }

    // public void Test() //for fast debugging
    // {
    //      DebugLog.text ="lkjsefseo"+Score.Variable.value.ToString();
    //     for(int i= 0; i< LockedIcons.Length; i++)
    //     {
    //         LockedIcons[Score.value].SetActive(true);
    //     }
    // }


}
