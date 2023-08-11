using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Monster : Character
{
    private float endPosX;

    public override void Attack()
    {
        throw new System.NotImplementedException();
    }

    public override void Die()
    {
        Debug.Log(gameObject.name + " Die");
    }

    public override void Spawn()
    {
        throw new System.NotImplementedException();
    }

    public void Move()
    {
        Vector2 tmp = transform.position;
        tmp -= new Vector2(Manager_Stage.Instance.MoveSpeed * Time.deltaTime, 0f);
        transform.position = tmp;
    }

    protected override void Start()
    {
        base.Start();
        endPosX = -Camera.main.orthographicSize * ((float)Screen.width / Screen.height);
    }

    protected override void Update()
    {
        Move();

        if (transform.position.x <= endPosX)
        {
            Die();
            Manager_Monster.Instance.RemoveMonster(gameObject.name);
        }
    }
}
