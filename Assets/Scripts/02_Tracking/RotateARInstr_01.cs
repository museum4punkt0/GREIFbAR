using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateARInstr_01 : MonoBehaviour
{
    private float rotationSpeed=1;
    private int count;
    // Update is called once per frame
    void Update()
    {
        // Let AR Rotate
        if(transform.eulerAngles.z > 1 && transform.eulerAngles.z<180){
            rotationSpeed = -1f;
        }
        if(transform.eulerAngles.z<359 && transform.eulerAngles.z>180){
            rotationSpeed = 1f;
            count++;
        }
        if(count<3){
            transform.Rotate(new Vector3(0,0,rotationSpeed)*Time.deltaTime);
        }
    }
}
