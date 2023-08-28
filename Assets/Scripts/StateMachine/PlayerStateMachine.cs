using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : StateMachineBehaviour
{
    protected Character_Player Player { get; private set; }

    virtual public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    virtual public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    virtual public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Player == null)
        {
            Player = Character_Player.Instance;
        }
        StateEnter(animator, stateInfo, layerIndex);
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateUpdate(animator, stateInfo, layerIndex);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        StateExit(animator, stateInfo, layerIndex);
    }
}
