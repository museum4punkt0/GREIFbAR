using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ARObjManager_03 : MonoBehaviour
{
    public GameObject loadedOBJ;
    private Vector3 objVector;
    private Vector3 objPos;
    private Vector3 objRot;
    private float[] vect = new float[3];
    [SerializeField]
    private Slider[] sliders;
    // Start is called before the first frame update
    void Start(){

        //Sets Loaded content
        objVector = loadedOBJ.transform.localScale;
        objRot = loadedOBJ.transform.localEulerAngles;
        objPos = loadedOBJ.transform.localPosition = new Vector3(0, 0, 0);
        vect[0] = vect[2] = 0f;
        vect[1] = 1f;
    }
    public void SetTop(int top){
        
        if(top == 0){
            vect[0] = vect[2] = 0f;
            vect[1] = 1f;
        }
        else if(top == 1){
            vect[0] = vect[1] = 0f;
            vect[2] = 1f;
        }
        else if(top == 2){
            vect[1] = vect[2] = 0f;
            vect[0] = 1f;
        }
        objVector = loadedOBJ.transform.localScale;
        objRot = loadedOBJ.transform.localEulerAngles;
        objPos = loadedOBJ.transform.localPosition;
        sliders[0].value = 1f;
        sliders[1].value = 0f;
        sliders[2].value = 0f;
    }
    public void RotateOBJ(float rotation)
    {
        loadedOBJ.transform.localEulerAngles = objRot + new Vector3(rotation*vect[0], rotation*vect[1], rotation*vect[2]);
    }

    // Update is called once per frame
    public void ResizeOBJ(float size)
    {
        size = size*size;
        loadedOBJ.transform.localScale = objVector*size;
    }
    
    public void PositionOBJ(float position)
    {
        loadedOBJ.transform.localPosition = objPos + new Vector3(position*vect[0], position*vect[1], position*vect[2]);
    }
}
