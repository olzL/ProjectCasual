using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSM_Resurrection : PlayerStateMachine
{
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player.Resurrection();
    }

    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float aniprogress = stateInfo.normalizedTime;
        if (aniprogress >= 1f)
        {
            animator.SetInteger("aniIndex", 0);
        }
    }

    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
