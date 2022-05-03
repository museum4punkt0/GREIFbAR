using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class IsVisible : MonoBehaviour
{
    public bool reset;
    private Transform transCamera;
    public GameObject handy;
    public Image arrow;
    public GameObject arrowChild;
    public ARSession arSession;

    void Start(){
       transCamera = Camera.main.transform;
    }
    void Update()
    {
        //Rotate Arrow
        if(handy!=null){
            // Sets direction of the AR content, if the content is not visible
            Vector3 dir = transCamera.InverseTransformPoint(handy.transform.position);
            float alpha =  Mathf.Atan2(dir.x, dir.y)*Mathf.Rad2Deg;
            alpha +=180;
            arrow.transform.localEulerAngles = new Vector3 (0,180,alpha);
            float dist = Vector3.Distance(transCamera.position, handy.transform.position);
            if(dist>2&&reset){
                arSession.Reset();
            }
        }

    }
    void OnBecameInvisible()
    {
        arrowChild.SetActive(true);
    }
    void OnBecameVisible()
    {
        arrowChild.SetActive(false);

    }
    public void ResetSession() {
       LoaderUtility.Deinitialize ();
       LoaderUtility.Initialize ();
       Debug.Log("Reset");
    }

}
