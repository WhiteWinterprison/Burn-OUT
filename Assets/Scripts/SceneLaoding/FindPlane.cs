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


    private ARPlaneManager m_PlaneManager;
    [SerializeField]
    private Image image;

    [SerializeField]
    private UnityEvent OnInitialized;

    private bool initDone = false;


    // Start is called before the first frame update
    void Start()
    {
        m_PlaneManager = GetComponent<ARPlaneManager>();
        m_PlaneManager.planesChanged += MyAction;
    

    }

    // Update is called once per frame
    void Update()
    {
 
    }

    void MyAction(ARPlanesChangedEventArgs args)
    {
        SceneManager.LoadScene("Menu");
    //    if(!initDone)
    //    {
    //        init();
    //    }
        
    }

    void init()
    {   
        image.enabled = false;
        OnInitialized?.Invoke();
        initDone = true;
    }
}
