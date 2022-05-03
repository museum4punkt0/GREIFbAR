using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ResetAR_99 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void ResetARSession()
    {
        
        ARSession arSession = GameObject.Find("AR Session").GetComponent<ARSession>();
        arSession.Reset();

    }
}
