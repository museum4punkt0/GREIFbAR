using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAR_02 : MonoBehaviour
{
    
    private float maxDistanceOnSelection = 20;
    public bool trigger;
    public Animator animator;
    public BTTN_Navigation nav;
    public GameObject gamObj;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger)
        {
            if (StartAnim_02.navScene>=3)
            {
                gamObj.SetActive(true);
                Triggering();
            }
            else
            {
                
                gamObj.SetActive(false);
            }
        }
        else
        {
            if(StartAnim_02.strtAnim==true)
            {
                StartAnim_02.strtAnim=false;
                animator.SetTrigger("GO");
            }
            StartAnim_02.navScene=nav.count;
        }
    }

    void Triggering()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
            {
                return;
            }

            // 
            Ray ray = Camera.main.ScreenPointToRay(touchPosition);
            RaycastHit hitObject;
            if(Physics.Raycast(ray, out hitObject, maxDistanceOnSelection))
            {
                if(hitObject.transform.gameObject == gameObject){

                    StartAnim_02.strtAnim=true;
                    animator.SetTrigger("GO");
                }
            }
    }
    bool TryGetTouchPosition(out Vector2 touchPos)
    {
        // if phone is touched
        if (Input.touchCount > 0)
        {
            touchPos = Input.GetTouch(0).position;
            return true;
        }
        touchPos = default;
        return false;
    }
}
