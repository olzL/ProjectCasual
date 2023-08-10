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
        // 카메라 중앙에서 화면 왼쪽 끝까지의 길이
        endPosX = -Camera.main.orthographicSize * ((float)Screen.width / Screen.height);

    }

    void Update()
    {
        transform.Translate(-1 * StageManager.Instance.MoveSpeed * Time.deltaTime, 0, 0);

        if (transform.position.x <= endPosX)
        {
            transform.Translate(-1 * (endPosX - startPosX), 0, 0);
        }
    }
}
