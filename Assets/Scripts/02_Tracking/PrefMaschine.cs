using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefMaschine : MonoBehaviour
{
    Vector3 scaleChange = new Vector3(2,2,2);
    Vector3 posChange = new Vector3(0.0f,2, 0.0f);
    public GameObject box;
    public GameObject machine;
    // Start is called before the first frame update
    void Start()
    {
        machine.transform.localPosition = new Vector3(machine.transform.localPosition.x,-0.626f ,machine.transform.localPosition.z);
        machine.SetActive(false);
        box.transform.localScale = new Vector3(0.1f,0.1f,0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        // Animation of the prefab -> it rises from the ground
        if(box.transform.localScale.x<1&&machine.transform.localPosition.y<0.368)
        {
            box.transform.localScale += scaleChange*Time.deltaTime;
        }
        else if(machine.transform.localPosition.y<0.368)
        {
            
            machine.SetActive(true);
            machine.transform.localPosition+=posChange*Time.deltaTime;    
        }
        else if(0<box.transform.localScale.x)
        box.transform.localScale -= scaleChange*Time.deltaTime;
        
    }
}
