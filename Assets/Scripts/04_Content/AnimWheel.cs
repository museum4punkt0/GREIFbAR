using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimWheel : MonoBehaviour
{
    // Start is called before the first frame update

    // Update is called once per frame
    public GameObject wheel2;
    private bool rotate = false;
    private float timer =0.2f;
    private int count=0;
    void Update()
    {
        if(rotate){
            transform.Rotate(new Vector3(0,0,30f)*Time.deltaTime);
            timer -= Time.deltaTime;
            if(count==25){
                wheel2.transform.Rotate(new Vector3(0,0,30f)*Time.deltaTime);
            }
            if (timer <0)
            {
                Debug.Log(count);
                count++;
                rotate =false;
                timer=0.2f;
                if(count>25)
                    count=0;
            }
        }
    }
    public void SetRotation()
    {
        rotate = true;
    }
}
