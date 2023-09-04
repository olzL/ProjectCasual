using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSM_Jump : PlayerStateMachine
{
    private bool _isJumpMax;
    private Vector3 _jumpPos;
    private Vector3 _defaultPos;
    private Vector3 _jumpMaxPos;

    override public void StateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _isJumpMax = false;
        _jumpPos = Vector3.zero;
        _defaultPos = Player.transform.position;
        _jumpMaxPos = new Vector3(Player.transform.position.x, Player.JumpMaxHeight, Player.transform.position.y);
    }

    override public void StateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Player.transform.position.y >= Player.JumpMaxHeight)
        {
            _isJumpMax = true;
            Player.transform.position = _jumpMaxPos;
        }

        if (_isJumpMax)
        {
            Player.VerticalSpeed -= Player.Gravity * Time.deltaTime;
        }

        _jumpPos.y = Player.VerticalSpeed * Time.deltaTime;
        Player.transform.position += _jumpPos;

        if (Player.transform.position.y < 0f)
        {
            Player.transform.position = _defaultPos;
            Player.VerticalSpeed = 0f;
            animator.SetInteger("aniIndex", 0);
        }
    }

    override public void StateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
