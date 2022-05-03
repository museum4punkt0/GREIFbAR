using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartImagTrack_04 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void StartImageTracking()
    {
        ARTrackedImageManager arIMG = GameObject.Find("AR Session Origin").GetComponent<ARTrackedImageManager>();
        if(arIMG)
        {
            arIMG.enabled = true;
            Debug.Log("ARFound");
        }
        
    }
}
