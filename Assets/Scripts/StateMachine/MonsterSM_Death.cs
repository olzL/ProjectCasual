using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSM_Death : StateMachineBehaviour
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        float aniProgress = stateInfo.normalizedTime;
        if (aniProgress >= 1f)
        {
            Character_Monster mon = Manager_Monster.Instance.AliveMonsterList.Find(o => animator.name == o.name);
            if (mon != null)
            {
                mon.Death();
            }
            animator.SetInteger("aniIndex", 0);
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

}
