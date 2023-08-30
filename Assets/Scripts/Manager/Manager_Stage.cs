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
        // 10000001: 스테이지 기본 속도
        MoveSpeed = Table_101_GlobalValue.Instance.DataDic[10000001].FloatValue; 
        Level = 1;
    }

    private void LevelUp()
    {
        Level++;

        // 10000002: 스테이지 레벨당 증가 속도
        MoveSpeed += Table_101_GlobalValue.Instance.DataDic[10000002].FloatValue; 
        LevelInit();

        // 10000003: 애니메이션 최대 증가 속도
        if (Level <= Table_101_GlobalValue.Instance.DataDic[10000003].FloatValue)
        {
            List<Character_Monster> aliveMonsterList = Manager_Monster.Instance.AliveMonsterList;
            for (int i = 0; i < aliveMonsterList.Count; i++)
            {
                aliveMonsterList[i].SetWalkAnimationSpeed(Level);
            }
            Character_Player.Instance.SetWalkAnimationSpeed(Level);
        }
    }

    public void EndStage()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        // 10000004: 스테이지 레벨업 간격(s)
        if (elapsedTime >= Table_101_GlobalValue.Instance.DataDic[10000004].FloatValue)
        {
            LevelUp();
            elapsedTime = 0f;
        }
    }
}
