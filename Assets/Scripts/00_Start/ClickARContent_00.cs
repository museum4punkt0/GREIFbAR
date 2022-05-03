using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
public class ClickARContent_00 : MonoBehaviour
{
    private float maxDistanceOnSelection = 20;
    public Image imgPanel;
    public GameObject objIcon;
    private bool moveIcon;
    void Awake()
    {
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

    // Update is called once per frame
    void Update()
    {
        if (moveIcon)
            MoveIcon();
         
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        // 
        Ray ray = Camera.main.ScreenPointToRay(touchPosition);
        RaycastHit hitObject;
        Debug.Log(Physics.Raycast(ray, out hitObject, maxDistanceOnSelection));
        if(Physics.Raycast(ray, out hitObject, maxDistanceOnSelection))
        {
            if (hitObject.transform.name.Contains("HandyCollider"))
            {

                moveIcon = true;
            }
        
        }
    }
    void MoveIcon()
    {
        //Scripted animation with scene change at the end
        objIcon.transform.localScale = Vector3.MoveTowards(objIcon.transform.localScale, new Vector3(1, 1, 1), 300*Time.deltaTime);
        Color col = imgPanel.color;
        col.a = 1/objIcon.transform.localScale.x;
        imgPanel.color = col;
        if (objIcon.transform.localScale.x == 1)
            {
                GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<SceneManger>().ChangeScene(1);
            }
    }
} 
    
