using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMarie : MonoBehaviour
{
    public Animator animMarie;
    public BTTN_Navigation nav;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
        animMarie.SetInteger("State", nav.count);
    }
}
