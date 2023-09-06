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
        float aniProgress = stateInfo.normalizedTime;
        if (aniProgress >= 1f)
        {
            Manager_Stage.Instance.Pause();
        }
    }

    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
