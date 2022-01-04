using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



// script für loading screen somit man 5 sekunden warten bis die nächste scene kommt
public class Loading : MonoBehaviour
{
    private IEnumerator Start()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(3);
    }
}
