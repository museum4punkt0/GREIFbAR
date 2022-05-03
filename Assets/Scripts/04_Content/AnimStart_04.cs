using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimStart_04 : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);
        animator.SetBool("start",false);
    }
}
