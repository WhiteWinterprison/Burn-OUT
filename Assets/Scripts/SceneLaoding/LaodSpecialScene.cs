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

    //Notlöung für Scene loading 
    //lädt scene via der Position die es im Buildeditor hat 
    public void LoadSceneWithInt(int WantedScene)
    {
        SceneManager.LoadScene(WantedScene);
    }
    public void Reload()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
    }


}
