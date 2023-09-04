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
    public float Gravity { get { return _gravity; } }
    public float JumpMaxHeight { get { return _jumpMaxHeight; } }
    public float VerticalSpeed
    {
        get { return _verticalSpeed; }
        set { _verticalSpeed = value; }
    }
    public BoxCollider2D AttackBoxCollider;

    [SerializeField]
    private float _jumpSpeed;
    [SerializeField]
    private float _jumpMaxHeight;
    [SerializeField]
    private float _gravity;
    [SerializeField]
    private float _verticalSpeed;

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
        InitData(11000001, 1);

        _jumpSpeed = _globalValueDic[10000005].FloatValue;
        _jumpMaxHeight = _globalValueDic[10000007].FloatValue;
        VerticalSpeed = 0f;

        StageLevelUp();
    }

    public void AttackClick()
    {
        MyAnimator.SetInteger("aniIndex", 1);
    }

    public void JumpClick()
    {
        if (VerticalSpeed == 0f)
        {
            VerticalSpeed = _jumpSpeed;
            MyAnimator.SetInteger("aniIndex", 3);
        }
    }

    protected override void StageLevelUp()
    {
        float gravityBase = _globalValueDic[10000006].FloatValue;
        float gravityAdd  = _globalValueDic[10000008].FloatValue;
        int stageLevel = Manager_Stage.Instance.StageLevel;

        _gravity = gravityBase + stageLevel * gravityAdd;
        WalkAnimationSpeedUp();
    }

    public override void Death()
    {
        throw new NotImplementedException();
    }
}
