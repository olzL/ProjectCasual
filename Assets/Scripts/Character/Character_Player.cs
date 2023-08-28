using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Player : Character
{
    private static Character_Player _instance = null;
    public static Character_Player Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject player = new GameObject("Player");
                player.AddComponent<Character_Player>();
                _instance = player.GetComponent<Character_Player>();
            }
            return _instance;
        }
    }
    public BoxCollider2D AttackBoxCollider;

    protected override void Awake()
    {
        base.Awake();

        if (_instance == null)
        {
            _instance = this;
        }
    }

    protected override void Start()
    {
        base.Start();
        // 플레이어 데이터 초기화
        InitData(11000001, 1);
    }

    /// <summary>
    /// aniIndex(0: Walk, 1: Attack)
    /// </summary>
    public void AnimatorSetInteger(string name, int value)
    {
        MyAnimator.SetInteger(name, value);
    }

    public override void Attack()
    {
        AnimatorSetInteger("aniIndex", 1);
    }

    public override void Die()
    {
        throw new NotImplementedException();
    }

    public override void Spawn()
    {
        throw new NotImplementedException();
    }

    protected override void Update()
    {
        //Move();
    }
}
