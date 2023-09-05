using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    float startPosX;
    float endPosX;

    void Start()
    {
        startPosX = transform.position.x;
        // ī�޶� �߾ӿ��� ȭ�� ���� �������� ����
        endPosX = -Camera.main.orthographicSize * ((float)Screen.width / Screen.height);
    }

    void Update()
    {
        if (Character_Player.Instance.IsAlive == true)
        {
            Move();
        }
    }

    private void Move()
    {
        transform.Translate(-1 * Manager_Stage.Instance.StageSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= endPosX)
        {
            transform.Translate(-1 * (endPosX - startPosX), 0, 0);
        }
    }
}
