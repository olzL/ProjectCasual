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
    private float _jumpVelocity;
    private float _gravity;
    public float _verticalVelocity;

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
        
        _jumpVelocity = Table_101_GlobalValue.Instance.DataDic[10000005].FloatValue; // 10000005: 플레이어 캐릭터 점프 속도
        _gravity = Table_101_GlobalValue.Instance.DataDic[10000006].FloatValue;      // 10000006: 플레이어 캐릭터 점프 중력
        _verticalVelocity = 0f;
    }

    private void Update()
    {
        Jump();
    }

    public void AttackButtonClick()
    {
        MyAnimator.SetInteger("aniIndex", 1);
    }

    public void JumpButtonClick()
    {
        if (_verticalVelocity == 0f)
        {
            _verticalVelocity = _jumpVelocity;
            MyAnimator.SetInteger("aniIndex", 3);
        }
    }

    private void Jump()
    {
        _verticalVelocity -= _gravity * Time.deltaTime;

        transform.position += new Vector3(0f, _verticalVelocity * Time.deltaTime, 0f);

        if (transform.position.y < 0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            _verticalVelocity = 0f;
            MyAnimator.SetInteger("aniIndex", 0);
        }
    }

    public override void Death()
    {
        throw new NotImplementedException();
    }
}
