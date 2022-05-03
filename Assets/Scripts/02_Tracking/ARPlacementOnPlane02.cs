using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARRaycastManager))]

public class ARPlacementOnPlane02 : MonoBehaviour
{
    public GameObject setGameObject;
    public GameObject setGameObject2;
    public GameObject setMockup;
    public GameObject instructionIMG;
    public GameObject body;
    public Slider slider;

    private GameObject spawnedMockup;
    private GameObject spawnedObject;
    private GameObject spawnedObject2;
    private ARRaycastManager _arRaycastManager;
    private ARPlaneManager _arPlaneManager;
    private Vector2 touchPosition;
    private GameObject defPlane;
    private bool isPlaced;
    private bool isPlaced2;
    private Canvas canv;
    private float planeSize;
    private bool isTracked;

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
        //Lets the user set the AR-objects on the plane by setting the pointer (spawnedMockup) in the middle of the scene
        if(!isPlaced){
            slider.value = ArPlane_BoundaryChanged();
            if (ArPlane_BoundaryChanged() > slider.maxValue)
                isTracked = true;
            }
        if (isTracked&&!isPlaced && _arRaycastManager.Raycast(new Vector2 (Screen.width/2,Screen.height/3f),hits, TrackableType.PlaneWithinPolygon))
        {
            //If planes are detected set Mockup
            var hitPose = hits[0].pose;
            if(spawnedMockup == null)
            {
                spawnedMockup = Instantiate(setMockup, hitPose.position, hitPose.rotation);
                
                Renderer rend = spawnedMockup.GetComponent<Renderer>();
                instructionIMG.SetActive(false);
                
            }
            else
            {
                spawnedMockup.transform.position = hitPose.position;
                spawnedMockup.transform.rotation = hitPose.rotation;
            }
        }
        if (!isPlaced && !isPlaced2 && slider.value>10 && spawnedMockup != null && _arRaycastManager.Raycast(new Vector2 (Screen.width*0.9f,Screen.height/3f),hits, TrackableType.PlaneWithinPolygon)) 
        {
            // Object is randomly placed
            var hitPose = hits[0].pose;
            isPlaced2=true;
            spawnedObject2 = Instantiate(setGameObject2, hitPose.position, hitPose.rotation);
        }
        if (!isPlaced && Input.touchCount>0 && spawnedMockup != null)
        {
            // if touched -> set AR object
            isPlaced=true;
            
            spawnedObject = Instantiate(setGameObject, spawnedMockup.transform.position, spawnedMockup.transform.rotation);
            Destroy (spawnedMockup);
            body.SetActive(false);

            foreach(var plane in _arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
            _arPlaneManager.enabled = false;
        }
        /*if(isPlaced){
            foreach(var plane in _arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
        }*/

    }

    private float ArPlane_BoundaryChanged() 
    {
        planeSize = 0;
        foreach (var plane in _arPlaneManager.trackables)
        {
            planeSize += CalculatePlaneArea(plane);
        }
        return planeSize;
    }
    private float CalculatePlaneArea(ARPlane plane) { return plane.size.x * plane.size.y; }
}
