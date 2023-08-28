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
    public BoxCollider2D HitBoxCollider { get; private set; }

    protected virtual void Awake()
    {
        _characterData = new CharacterData();

        if (HitBoxCollider == null)
        {
            HitBoxCollider = gameObject.AddComponent<BoxCollider2D>();
        }
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
        Name = _characterData.Name.ToString();
        Atk = _characterData.AtkBase + level * _characterData.AtkAdd;
        Hp = _characterData.HpBase + level * _characterData.HpAdd;
        HitBoxCollider.size = new Vector2(_characterData.ScaleX, _characterData.ScaleY);
    }

    public void Hit(Character attackChar)
    {
        Hp -= attackChar.Atk;
        Debug.Log(gameObject.name + "ÀÇ HP = " + Hp);

        if (Hp <= 0)
        {
            Die();
        }
    }
}
