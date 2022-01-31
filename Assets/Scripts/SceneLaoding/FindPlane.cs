using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class FindPlane : MonoBehaviour

    
{

    [SerializeField]
    ARPlaneManager m_PlaneManager;
    
    public ARPlaneManager planeManager
    {
        get => m_PlaneManager;
        set => m_PlaneManager = value;
    }
    [SerializeField]
    private Image image;

    private bool PlanesFound() {
        if(m_PlaneManager.trackables.count > 0)
        {   
            Application.Quit();
            return true;
        }
        else{
            return false;
            }
 
    }


    // Start is called before the first frame update
    void Start()
    {
        m_PlaneManager = GetComponent<ARPlaneManager>();
    

    }

    // Update is called once per frame
    void Update()
    {
        bool asdf = PlanesFound();
    }

}
