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

        BoxCollider2D playerAttackBox = Player.AttackBoxCollider;
        List<Character_Monster> monsterPool = Manager_Monster.Instance.AliveMonsterList;

        float aniProgress = stateInfo.normalizedTime;
        if (aniProgress >= 1f)
        {
            for (int i = 0; i < monsterPool.Count; i++)
            {
                if (playerAttackBox.bounds.Intersects(monsterPool[i].HitBoxCollider.bounds))
                {
                    Debug.LogFormat(" \"{0}\"에게 공격 성공 (데미지: {1})", monsterPool[i].name, Player.Atk);
                    monsterPool[i].Hit(Player);
                }
            }

            Player.AnimatorSetInteger("aniIndex", 0);
        }
    }

    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("공격 종료");
    }
}
