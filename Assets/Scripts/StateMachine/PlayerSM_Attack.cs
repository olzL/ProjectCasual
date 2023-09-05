using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerSM_Attack : PlayerStateMachine
{
    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        BoxCollider2D playerAttackBox = Player.AttackBoxCollider;
        List<Character_Monster> monsterPool = Manager_Monster.Instance.AliveMonsterList;

        float aniProgress = stateInfo.normalizedTime;
        if (aniProgress >= 1f)
        {
            if (monsterPool != null && monsterPool.Count != 0)
            {
                int monsterIndex = 0;
                for (int i = 0; i < monsterPool.Count; i++)
                {
                    if (monsterPool[i].Type == ECharacterType.Monster)
                    {
                        monsterIndex = i;
                        break;
                    }
                }

                if (playerAttackBox.bounds.Intersects(monsterPool[monsterIndex].HitBoxCollider.bounds))
                {
                    monsterPool[monsterIndex].Hit(Player);
                }
                animator.SetInteger("aniIndex", 0);
            }
        }
    }

    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
