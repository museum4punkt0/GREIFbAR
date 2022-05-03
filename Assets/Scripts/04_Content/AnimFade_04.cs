using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class AnimFade_04 : MonoBehaviour
{
    private Transform transCamera;
    public GameObject Enigma;
    public GameObject Enigma_Outer;

    void Start(){
       transCamera = Camera.main.transform;
    }
    void Update()
    {
        //Rotate Arrow
        if(Enigma!=null){
            //Vector3 dir = handy.transform.TransformDirection(transCamera.position);
            float dist = Vector3.Distance(transCamera.position, Enigma.transform.position);
            if(dist<1 && dist>0.5f){
               Color objColor = Enigma.GetComponent<Renderer>().material.color;
               objColor.a = dist;
               Enigma.GetComponent<Renderer>().material.color = objColor;
               Debug.Log(dist);
            }
            else if(dist>1.2 && dist<=1.4)
            {
                Color objColor = Enigma_Outer.GetComponent<Renderer>().material.color;
                objColor.a = (dist-1.2f)*5f;
                Enigma_Outer.GetComponent<Renderer>().material.color = objColor;
                Debug.Log(dist);
            }
            
        }

    }
}
