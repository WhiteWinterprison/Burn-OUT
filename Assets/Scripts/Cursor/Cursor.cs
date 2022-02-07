using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Cursor : MonoBehaviour
{
    private ARRaycastManager rayManager;
    [HideInInspector] public GameObject visual;
    //private GameObject visual;

    public GameObject RoomScan;
    [HideInInspector]public bool FloorIsFound;

    void Start()
    {
        //get components
        rayManager = FindObjectOfType<ARRaycastManager>();
        visual = transform.GetChild(0).gameObject; //Symbol for the Cursor

        //hide Cursor
        visual.SetActive(false);
        RoomScan.SetActive(true);
        FloorIsFound = false;
    }

    void Update()
    {
        //shoot a raycast from center of the screen
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        rayManager.Raycast(new Vector2(Screen.width / 2, Screen.height / 2), hits, TrackableType.Planes);

        //if hitting AR plane, update the position and rotation
        if (hits.Count > 0)
        {
            transform.position = hits[0].pose.position;
            transform.rotation = hits[0].pose.rotation;

            if (!visual.activeInHierarchy)
            {
                visual.SetActive(true); //enables visual
                RoomScan.SetActive(false);
                FloorIsFound = true;
            }
        }

    }
}