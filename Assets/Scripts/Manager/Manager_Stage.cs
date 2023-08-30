using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Stage : MonoSingleton<Manager_Stage>
{
    public float MoveSpeed { get; private set; } // �� �� ���� �̵� �ӵ�
    public int Level { get; private set; }       // �������� ����
    public Action LevelInit;

    private float elapsedTime;

    private void Start()
    {
        // 10000001: �������� �⺻ �ӵ�
        MoveSpeed = Table_101_GlobalValue.Instance.DataDic[10000001].FloatValue; 
        Level = 1;
    }

    private void LevelUp()
    {
        Level++;

        // 10000002: �������� ������ ���� �ӵ�
        MoveSpeed += Table_101_GlobalValue.Instance.DataDic[10000002].FloatValue; 
        LevelInit();

        // 10000003: �ִϸ��̼� �ִ� ���� �ӵ�
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

        // 10000004: �������� ������ ����(s)
        if (elapsedTime >= Table_101_GlobalValue.Instance.DataDic[10000004].FloatValue)
        {
            LevelUp();
            elapsedTime = 0f;
        }
    }
}
