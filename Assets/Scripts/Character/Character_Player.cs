using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

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

    [SerializeField] Animator[] _aniamtor;

    float _moveSpeed;

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
        _moveSpeed = 20;
    }

    /// <summary>
    /// aniIndex(0: Idle, 1: Walk, 2: Attack)
    /// </summary>
    public void AnimatorSetInteger(string name, int value)
    {
        for (int i = 0; i < _aniamtor.Length; i++)
        {
            _aniamtor[i].SetInteger(name, value);
        }
    }

    public override void Move()
    {
        Vector2 tmp = transform.position;
        tmp += new Vector2(_moveSpeed * Time.deltaTime, 0f);
        transform.position = tmp;
    }

    public override void Attack()
    {
        // АјАн 
        AnimatorSetInteger("aniIndex", 2);
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
        Move();
    }
}
