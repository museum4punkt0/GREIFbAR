using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class StartImageAR_04 : MonoBehaviour
{
    [SerializeField]
    ARSession arSession;

    private void Start()
    {
        arSession.Reset();
    }
}
