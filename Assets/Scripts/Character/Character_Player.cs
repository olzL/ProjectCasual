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
    public float JumpSpeed { get { return _jumpSpeed; } }
    public float JumpMaxHeight { get { return _jumpMaxHeight; } }
    public float Gravity { get { return _gravity; } }
    public bool IsAlive { get { return _isAlive; } }
    public bool IsHit { get { return _isHit; } }
    public float VerticalSpeed
    {
        get { return _verticalSpeed; }
        set { _verticalSpeed = value; }
    }
    public BoxCollider2D AttackBoxCollider;
    public Action DeathAction;

    private float _jumpSpeed;
    private float _jumpMaxHeight;
    private float _gravity;
    private bool _isAlive;
    private bool _isHit;
    private float _verticalSpeed;

    private float _hitImmunityTime;
    private float _ResurImmunityTime;

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
        _jumpMaxHeight = _globalValueDic[10000007].FloatValue;
        _hitImmunityTime = _globalValueDic[10000010].FloatValue;
        _ResurImmunityTime = _globalValueDic[10000011].FloatValue;
        VerticalSpeed = 0f;
        _isAlive = true;
        _isHit = false;

        SetHitBox(new Vector2(0.5f, 1f),new Vector2(-0.3f, 0f));
        StageLevelUp();
    }

    private void Update()
    {
        MonsterToCollision();
    }

    public void Attack()
    {
        List<Character_Monster> monsterPool = Manager_Monster.Instance.AliveMonsterList;
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

            if (AttackBoxCollider.bounds.Intersects(monsterPool[monsterIndex].HitBoxCollider.bounds))
            {
                monsterPool[monsterIndex].Hit(this);
            }
        }
    }

    public void MonsterToCollision()
    {
        List<Character_Monster> monsterPool = Manager_Monster.Instance.AliveMonsterList;
        if (_isHit == false && _isAlive == true)
        {
            if (monsterPool != null && monsterPool.Count != 0)
            {
                if (HitBoxCollider.bounds.Intersects(monsterPool[0].HitBoxCollider.bounds))
                {
                    StartCoroutine(DamageImmunity(_hitImmunityTime));
                    PlayAnimation(4);
                    Hit(monsterPool[0]);
                }
            }
        }
    }

    public void Jump()
    {
        if (VerticalSpeed == 0f)
        {
            PlayAnimation(3);
        }
    }

    private IEnumerator DamageImmunity(float time)
    {
        _isHit = true;
        yield return new WaitForSeconds(time);
        _isHit = false;
    }

    protected override void StageLevelUp()
    {
        float gravityBase = _globalValueDic[10000006].FloatValue;
        float gravityAdd = _globalValueDic[10000008].FloatValue;
        int stageLevel = Manager_Stage.Instance.StageLevel;

        _gravity = gravityBase + stageLevel * gravityAdd;
        WalkAnimationSpeedUp();
    }

    public override void Death()
    {
        Manager_Stage.Instance.Pause();
        _isAlive = false;
        DeathAction();
    }

    public void Resurrection()
    {
        Manager_Stage.Instance.Play();
        StartCoroutine(DamageImmunity(_ResurImmunityTime));
        SetHp(MaxHp);
        _isAlive = true;
    }
}
