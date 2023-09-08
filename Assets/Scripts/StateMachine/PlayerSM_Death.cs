using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSM_Death : PlayerStateMachine
{
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float aniprogress = stateInfo.normalizedTime;
        if (aniprogress >= 1f)
        {
            Player.Death();
        }
    }

    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
