using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// script f�r loading screen somit man 5 sekunden warten bis die n�chste scene kommt
public class Loading : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(3);
    }
}
