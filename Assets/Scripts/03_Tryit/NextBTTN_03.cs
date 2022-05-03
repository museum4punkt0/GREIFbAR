using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class NextBTTN_03 : MonoBehaviour
{
    [SerializeField]
    public ARPlacementOnPlane tapManager;
    public ARTrackedImageManager imgManager;

    [SerializeField]
    private GameObject objManager;
    public GameObject arObj;
    public GameObject hideObj;
    public void NxtBTTN(){
        //arObj = objManager.GetComponent<ARObjManager_03>().loadedOBJ;
        tapManager.setGameObject = arObj;
        imgManager.trackedImagePrefab = arObj;
        hideObj.SetActive(false);
    }
}
