using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleObject_99 : MonoBehaviour
{
    [SerializeField] private Vector3 maxLocalScale;
    [SerializeField] private Vector3 minLocalScale;
    private Transform _selection; // keep track of the current selction
    private float maxlocalScaleMagnitude;
    private float minlocalScaleMagnitude;
    private float initialFingersDistance;
    private Vector3 initialScale;

    void Start()
    {
        maxlocalScaleMagnitude = maxLocalScale.magnitude;
        minlocalScaleMagnitude = minLocalScale.magnitude;
    }

    private void Update()
    {
        // Handle a single touch
        if (Input.touchCount == 2)
        {
            Touch t1 = Input.GetTouch(0);
            Touch t2 = Input.GetTouch(1);
            //var touch = Input.GetTouch(0);

            if (t1.phase == TouchPhase.Began || t2.phase == TouchPhase.Began)
            {
                initialFingersDistance = Vector2.Distance(t1.position, t2.position);
                initialScale = transform.localScale;
            }

            // scale the object according to the finger movement
            if (t1.phase == TouchPhase.Moved || t2.phase == TouchPhase.Moved)
            {
                var currentFingersDistance = Vector2.Distance(t1.position, t2.position);
                var scaleFactor = currentFingersDistance / initialFingersDistance;

                Vector3 resultingSize = initialScale * scaleFactor;
                float resultingSizeMagnitude = resultingSize.magnitude;

                // if the resulting size is within the range then perform the transformation
                if (resultingSizeMagnitude >= minlocalScaleMagnitude && resultingSizeMagnitude <= maxlocalScaleMagnitude)
                {
                    transform.localScale = resultingSize;
                }
                else
                {
                    // if the resulting size would cross the borders then take the minimum or maximum size instead
                    if (resultingSizeMagnitude <= minlocalScaleMagnitude)
                    {
                        transform.localScale = minLocalScale;
                    }
                    else transform.localScale = maxLocalScale;
                }
                
            }
        }
    }
}
