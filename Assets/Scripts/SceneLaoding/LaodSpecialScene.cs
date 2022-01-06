using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class LaodSpecialScene : MonoBehaviour
{
    //public UnityEvent OnSceneFinishLoad;
    // private static LaodSpecialScene _instance; //for singelton

    // public static LaodSpecialScene Instance { get { return _instance; } }
    void Awake()
    {
    //    DontDestroyOnLoad(transform.gameObject);

    //      if(_instance != null && _instance  != this) //singelton pattern
    //      {
    //          Destroy(this.gameObject);
    //      }else
    //      {
    //          _instance = this;
    //      }
        
    }

    public void LoadScene(Object newScene){

        string sceneName = newScene ? newScene.name : "Tutorial";
        SceneManager.LoadScene(sceneName); //kein string t????
    }
}


  //single so only one scene is loaded

        //SceneManager.LoadScene("Menu");  //klappt
        //OnSceneFinishLoad.Invoke();
        //string testString = newScene.name;