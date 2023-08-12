using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerStateMachine
{
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //float aniProgress = stateInfo.normalizedTime % 1.0f;
        float aniProgress = stateInfo.normalizedTime;
        if (aniProgress >= 1f)
        {
            Character_Player.Instance.AnimatorSetInteger("aniIndex", 0);
        }
    }

    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("���� ����");
    }
}
