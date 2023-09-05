using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Stage : MonoSingleton<Manager_Stage>
{
    public float StageSpeed { get; private set; }   // 맵 및 몬스터 이동 속도
    public int StageLevel { get; private set; }     // 스테이지 레벨
    public Action LevelInit;                        // 레벨업 시 실행될 함수들

    private float _elapsedTime;
    private float _stageSpeedBase;
    private float _stageSpeedAdd;
    private float _levelUpInterval;

    private Dictionary<int, GlobalValueData> _globalValueDic;

    private void Start()
    {
        _globalValueDic = Table_101_GlobalValue.Instance.DataDic;
        _stageSpeedBase = _globalValueDic[10000001].FloatValue;
        _stageSpeedAdd = _globalValueDic[10000002].FloatValue;
        _levelUpInterval = _globalValueDic[10000004].FloatValue;

        StageSpeed = _stageSpeedBase;
        StageLevel = 1;
    }

    private void LevelUp()
    {
        StageLevel++;
        StageSpeed += _stageSpeedAdd;
        LevelInit();
    }

    public void EndStage()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (Character_Player.Instance.IsAlive == true)
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime >= _levelUpInterval)
            {
                LevelUp();
                _elapsedTime = 0f;
            }
        }
    }
}
