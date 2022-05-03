using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]
public class ARTapToPlace_01 : MonoBehaviour
{
    public GameObject setGameObject;
    public GameObject instructionIMG;

    private GameObject spawnedObject;
    private ARRaycastManager _arRaycastManager;
    private ARPlaneManager _arPlaneManager;
    private Vector2 touchPosition;
    private GameObject defPlane;

    static List<ARRaycastHit> hits = new List<ARRaycastHit>();
    void Awake()
    {
        _arRaycastManager = GetComponent<ARRaycastManager>();
        _arPlaneManager = GetComponent<ARPlaneManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPos)
    {
        if (Input.touchCount>0)
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
        //Lets the user set the AR-objects on the plane by touching it
        if(!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }
        if(_arRaycastManager.Raycast(touchPosition, hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = hits[0].pose;

            if(spawnedObject == null)
            {
                spawnedObject = Instantiate(setGameObject, hitPose.position, hitPose.rotation);
                instructionIMG.SetActive(false);
                foreach(var plane in _arPlaneManager.trackables)
                {
                    plane.gameObject.SetActive(false);
                }
                _arPlaneManager.enabled = false;
            }
            /*
            else
            {
                spawnedObject.transform.position = hitPose.position;
            }
            */
        }
    }
}
