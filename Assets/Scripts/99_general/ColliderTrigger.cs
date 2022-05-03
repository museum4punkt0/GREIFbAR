using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ColliderTrigger : MonoBehaviour
{
    public EventTrigger.TriggerEvent customTapCallback;
    // Update is called once per frame
    void Update()
    {

        /*if(!TryGetTouchPosition(out Vector2 touchPosition)) {
            return; 
        } 
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        */
        if(!Input.GetMouseButtonUp(0))
        {
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100.0f)) 
        {
            // check if this gameObject got hit
            if(hit.transform.gameObject == gameObject) {
                BaseEventData eventData= new BaseEventData(EventSystem.current);
                hit.transform.gameObject.GetComponent<ColliderTrigger>().customTapCallback.Invoke(eventData);
            }
        }
        
    }
    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }
        touchPosition = default;
        return false;
    }
}
