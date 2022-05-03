using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

[RequireComponent(typeof(ARPlaneManager))]
public class ARAutoSet_00 : MonoBehaviour
{
    public GameObject setGameObject;

    [SerializeField]
    private ARPlaneManager arPlaneManager;
    private GameObject placedObject;
    
    private Vector3 objectPos;
    void Awake()
    {
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.planesChanged += PlaneFound;
    }
    
    // Instantiates new AR-object at a certain pont
    private void PlaneFound(ARPlanesChangedEventArgs args)
    {
        if(args.added != null)
        {
            ARPlane arPlane = args.added[0];
            objectPos = new Vector3(arPlane.transform.position.x,Camera.main.transform.position.y, arPlane.transform.position.z);
            placedObject = Instantiate(setGameObject, objectPos, Quaternion.identity);
            arPlaneManager.enabled = false;
            foreach (var plane in arPlaneManager.trackables)
            {
                plane.gameObject.SetActive(false);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
