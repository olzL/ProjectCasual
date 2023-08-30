using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Monster : Character
{
    public bool IsAlive { get {return _isAlive; } }

    private float _endPosX;
    private bool _isAlive;

    protected override void Start()
    {
        base.Start();
        _isAlive = true;
        _endPosX = -Camera.main.orthographicSize * ((float)Screen.width / Screen.height) -1;
    }

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Death()
    {
        _isAlive = false;
        MyAnimator.SetInteger("aniIndex", 2);
        Manager_Monster.Instance.RemoveMonster(gameObject.name);
    }

    public void Respawn()
    {
        _isAlive = true;
        gameObject.SetActive(true);
    }

    public void Move()
    {
        Vector2 tmp = transform.position;
        tmp -= new Vector2(Manager_Stage.Instance.MoveSpeed * Time.deltaTime, 0f);
        transform.position = tmp;
    }

    protected override void Update()
    {
        if (_isAlive == true)
        {
            Move();
        }

        if (transform.position.x <= _endPosX)
        {
            Death();
        }
    }
}
