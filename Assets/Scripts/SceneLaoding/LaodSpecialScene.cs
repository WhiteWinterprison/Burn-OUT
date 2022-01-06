using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class LaodSpecialScene : MonoBehaviour
{
    public UnityEvent OnSceneFinishLoad;
    private static LaodSpecialScene _instance; //for singelton

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

         #region Singelton
     //      if(_instance != null && _instance  != this) //singelton pattern
    //      {
    //          Destroy(this.gameObject);
    //      }else
    //      {
    //          _instance = this;
    //      }
        #endregion
        
    }

    public void LoadScene(Object newScene)
    {

        string sceneName = newScene ? newScene.name : "Tutorial";
        SceneManager.LoadScene(sceneName); 
    }
}
