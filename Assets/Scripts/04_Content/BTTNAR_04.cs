using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BTTNAR_04 : MonoBehaviour
{

    public EventTrigger.TriggerEvent customTapCallback;
    public BTTN_Navigation Bttn_nav;
    // Update is called once per frame
    public void NextBTTN(int i)
    {
        if(Bttn_nav.count==i){
            BaseEventData eventData= new BaseEventData(EventSystem.current);
            customTapCallback.Invoke(eventData);
            Debug.Log(i+"worked");
        }
    }
}
