using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationImage_04 : MonoBehaviour
{
    [SerializeField]
    BTTN_Navigation nav;
    
    [SerializeField]
    Animator animator;
    [SerializeField]
    int i;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(nav.count == i)
        animator.enabled = true;
        else
        animator.enabled = false;
    }
}
