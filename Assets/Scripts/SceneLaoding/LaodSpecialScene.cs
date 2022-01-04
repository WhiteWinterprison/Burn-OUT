//Isabel because i dont get Jane script to work
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LaodSpecialScene : MonoBehaviour
{
 [SerializeField]
 private int RayCast;
 [SerializeField]
 private int ImageTracking;

 [SerializeField]
 private int UI;

 [SerializeField]
 private int Feet;

 [SerializeField]
 private int Sample;
     public void LoadRay()
    {
        SceneManager.LoadScene(RayCast);
    }

     public void LoadUi()
    {
        SceneManager.LoadScene(UI);
    }

     public void LoadImage()
    {
        SceneManager.LoadScene(ImageTracking);
    }

     public void LoadFeet()
    {
        SceneManager.LoadScene(Feet);
    }

       public void LoadSample()
    {
        SceneManager.LoadScene(Sample);
    }

}
