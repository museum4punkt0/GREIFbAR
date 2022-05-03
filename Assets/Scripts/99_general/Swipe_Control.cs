using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe_Control : MonoBehaviour
{
    private bool tap;
    private bool isDraging;
    private Vector2 startTouch;

    // durch EVENTSYSTEM ersetzen: https://www.youtube.com/watch?v=gx0Lt4tCDE0
    public Vector2 SwipeDelta { get; private set; }
    public bool SwipeL { get; private set; }
    public bool SwipeR { get; private set; }
    public bool SwipeU { get; private set; }
    public bool SwipeD { get; private set; }


    private void Update()
    {
        tap = SwipeL = SwipeR = SwipeU = SwipeD = false;
        #region Standalone Inputs
        // Swiping with the mouse
        if (Input.GetMouseButtonDown(0))
        {

            tap = true;
            isDraging = true;
            startTouch = Input.mousePosition;

        }
        else if (Input.GetMouseButtonUp(0))
        {
            Reset();
        }
        #endregion

        #region Mobile Inputs
        // Swiping on the phone
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                tap = true;
                isDraging = true;
                startTouch = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                isDraging = false;
                Reset();
            }
        }
        #endregion

        // Determine the distance
        SwipeDelta = Vector2.zero;
        if (isDraging)
        {

            if (Input.touches.Length > 0)
                SwipeDelta = Input.touches[0].position - startTouch;
            else if (Input.GetMouseButton(0))
                SwipeDelta = (Vector2)Input.mousePosition - startTouch;
        }

        // Activate swiping
        if (SwipeDelta.magnitude > 120)
        {
            // determine direction
            float x = SwipeDelta.x;
            float y = SwipeDelta.y;
            if (Mathf.Abs(x) > Mathf.Abs(y))
            {
                //Left and Right
                if (x < 0)
                    SwipeL = true;  
                else if (x > 0)
                    SwipeR = true;
            }
            else if (Mathf.Abs(y) > Mathf.Abs(x))
            {
                //Up and Down
                if (y < 0)
                {
                    SwipeD = true;
                }
                else if (y > 0)
                {
                    SwipeU = true;
                }
            }
            

            Reset();
        }
    }

    private void Reset()
    {
        startTouch = SwipeDelta = Vector2.zero;
        isDraging = false;
    }
}