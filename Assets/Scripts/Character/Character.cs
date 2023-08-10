using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    CharacterInfo _characterInfo;

    protected virtual void Awake()
    {
        _characterInfo = new CharacterInfo();
    }

    protected virtual void OnEnable()
    {
        InitData();
    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public abstract void Move();
    public abstract void Attack();
    public abstract void Die();
    public abstract void Spawn();

    // 몬스터 데이터 초기화
    public void InitData()
    {
        _characterInfo.Name = gameObject.name;
        _characterInfo.Level = 10;
        _characterInfo.Hp = 100;
        _characterInfo.Atk = 10;
        _characterInfo.Def = 10;
        _characterInfo.IsAttack = false;
    }

    public void Hit(CharacterInfo characterInfo)
    {
        int damage = characterInfo.Atk - _characterInfo.Def;
        _characterInfo.Hp -= damage;
        Debug.Log(_characterInfo.Name + "의 HP = " + _characterInfo.Hp);

        if (_characterInfo.Hp <= 0)
        {
            Die();
        }
    }
}
