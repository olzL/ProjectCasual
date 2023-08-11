using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Stage : MonoSingleton<Manager_Stage>
{
    public float MoveSpeed { get; private set; } // 맵 및 몬스터 이동 속도
    public int Level { get; private set; }       // 스테이지 레벨
    public Action LevelInit;

    private float elapsedTime;

    private void Start()
    {
        MoveSpeed = 5.0f;
        Level = 1;
    }

    private void LevelUp()
    {
        Level++;
        MoveSpeed += 3.0f;
        LevelInit();
    }

    public void EndStage()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= 5f)
        {
            LevelUp();
            elapsedTime = 0f;
        }
    }
}
