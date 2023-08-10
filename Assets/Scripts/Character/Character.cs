using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    CharacterData _characterData;

    public string Name { get; private set; }
    public int Hp { get; private set; }
    public int Atk { get; private set; }

    protected virtual void Awake()
    {
        _characterData = new CharacterData();
    }

    protected virtual void OnEnable()
    {

    }

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {

    }

    public abstract void Attack();
    public abstract void Die();
    public abstract void Spawn();

    public void InitData(int index, int level)
    {
        _characterData = Table_110_Character.Instance.DataList.Find(o => o.Index == index);
        Name = "GoblinInst";
        Atk = _characterData.AtkBase + level * _characterData.AtkAdd;
        Hp = _characterData.HpBase + level * _characterData.HpAdd;
    }

    public void Hit(CharacterInfo characterInfo)
    {
        Hp -= Atk;
        Debug.Log(_characterData.Name + "ÀÇ HP = " + Hp);

        if (Hp <= 0)
        {
            Die();
        }
    }
}
