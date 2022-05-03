using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMat_00 : MonoBehaviour
{
    // Start is called before the first frame update
    float timer = 4.0f;
    public Material material1;
    public Material material2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //sets new Material to let Button blink
        timer -= Time.deltaTime;
        
        if(timer<0)
        {
            Material[] mats = GetComponent<Renderer>().materials;
            mats[3] = material2;
            GetComponent<Renderer>().materials = mats;
            
        }
        if(timer<-0.5f)
        {
            Material[] mats = GetComponent<Renderer>().materials;
            mats[3] = material1;
            GetComponent<Renderer>().materials = mats;
            timer=1.5f;
        }
    }
}
