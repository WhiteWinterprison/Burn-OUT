using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class PlaceAndMovePlayingFields : MonoBehaviour
{
    #region Variablen
    [SerializeField ]
    GameObject  PlayingField;

    
    private GameObject spawnedObject;
    private ARRaycastManager m_RaycastManager;
    private Vector2 touchPos;

    //private ModeSelection m_modeSelection;


    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
         
    #endregion

   // Start is called before the first frame update
    private void Awake()
    {
        m_RaycastManager = GetComponent<ARRaycastManager>();
       // m_modeSelection = GetComponent<ModeSelection>();
    }

    bool TryToGetTouchPosition(out Vector2 touchPos)
    {
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            return true;
        }

        touchPos = default;
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!TryToGetTouchPosition(out Vector2 touchPos))
            return;

        if (m_RaycastManager.Raycast(touchPos, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            // s_Hits[0] == will be the closest hit.
            var hitPose = s_Hits[0].pose;

            if (spawnedObject == null)
            {
                spawnedObject = Instantiate(PlayingField, hitPose.position, hitPose.rotation);
                //UI.SetActive(true);
                // UI.transform.position = spawnedObject.transform.position;
                // UI.transform.rotation = spawnedObject.transform.rotation;
                // UI.transform.parent = spawnedObject.transform;
            }
            else
            {
                // if(m_modeSelection.movePlayingField)
                //     spawnedObject.transform.position = hitPose.position;
            }
        }
    }
}


