using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSM_Hit : PlayerStateMachine
{
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Player.IsHit == false)
        {
            animator.SetInteger("aniIndex", 0);
        }
    }

    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
