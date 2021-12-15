using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

//Requirment that will be added when using the script
[RequireComponent(typeof(ARRaycastManager))]
[RequireComponent(typeof(ARPlaneManager))]
[RequireComponent(typeof(ARAnchorManager))]

public class AnchorManager : MonoBehaviour
{

    #region Ar References
    private ARRaycastManager m_rayCastManager;
    private ARPlaneManager m_planeManager;
    private ARAnchorManager m_anchorManager;
    #endregion

    //Listen
    private List<ARAnchor> anchorList = new List<ARAnchor>();
    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    //Variables
    [SerializeField]
    private GameObject playField;

    void Awake()
    { 
        //get Components on awake
        m_rayCastManager = GetComponent<ARRaycastManager>();
        m_planeManager   = GetComponent<ARPlaneManager>();
        m_anchorManager  = GetComponent<ARAnchorManager>();
    }

    [System.Obsolete]
    void update()
    {
        //Check if screen touched
        if(Input.touchCount == 0)
        {
            return;
        }

        //if we move finger or stuff DONT do anything 
        Touch touch = Input.GetTouch(0);
        if(touch.phase != TouchPhase.Began)
        {
            return;
        }

        //RayCast 
        if(m_rayCastManager.Raycast(touch.position, hits,TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose; //get first hit position 
            ARAnchor AnchorPoint = m_anchorManager.AddAnchor(hitPose); //create Anchor Point where Raycast hit the planeS  //!! AddAnchor ist veraltet !!

            if(AnchorPoint == null)
            {
                //if no Anchor Point can be created
                Debug.Log("Anchor Point could not be created");
            }
            else
            {
                //if Anchor Point can be created add the new Anchor to a list
                anchorList.Add(AnchorPoint);
                //playField = Instantiate;

            }
        }

    }

}
