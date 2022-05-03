using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Rotation1Finger_99 : MonoBehaviour
{
    public float rotationSpeed;
    private Vector2 lastPos;
    
    private void Update()
    {
        // Handle a single touch
        if (Input.touchCount == 1)
        {
            var touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    // store the initial touch position
                    lastPos = touch.position;
                    break;

                case TouchPhase.Moved:
                    // get the moved difference and convert it to an angle
                    // using the rotationSpeed as sensibility
                if(Math.Abs(touch.position.x - lastPos.x)>Math.Abs(touch.position.y - lastPos.y))
                {
                    var rotationX = (touch.position.x - lastPos.x) * rotationSpeed;
                    transform.Rotate(Vector3.up, -rotationX, Space.World);
                    lastPos = touch.position;
                    break;
                }
                else
                {
                    // get the moved difference and convert it to an position
                    var rotationY = (touch.position.y - lastPos.y);
                    transform.localPosition += new Vector3(0, rotationY*0.001f, 0);
                    lastPos = touch.position;
                    break;
                }
            }
        }
    }
}
