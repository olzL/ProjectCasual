using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Stage : MonoSingleton<Manager_Stage>
{
    public float StageSpeed { get; private set; } // 맵 및 몬스터 이동 속도
    public int StageLevel { get; private set; }       // 스테이지 레벨
    public Action LevelInit;                     // 레벨업 시 실행될 함수들

    private float _elapsedTime;
    private float _stageSpeedBase;
    private float _stageSpeedAdd;
    private float _aniSpeedMax;
    private float _levelUpInterval;

    private Dictionary<int, GlobalValueData> _globalValueDic;

    private void Start()
    {
        _globalValueDic = Table_101_GlobalValue.Instance.DataDic;

        _stageSpeedBase = _globalValueDic[10000001].FloatValue;
        _stageSpeedAdd = _globalValueDic[10000002].FloatValue;
        _aniSpeedMax = _globalValueDic[10000003].FloatValue;
        _levelUpInterval = _globalValueDic[10000004].FloatValue;

        StageSpeed = _stageSpeedBase;
        StageLevel = 1;
    }

    private void LevelUp()
    {
        StageLevel++;
        
        StageSpeed += _stageSpeedAdd;
        LevelInit();
        
        //if (StageLevel <= _aniSpeedMax)
        //{
        //    List<Character_Monster> aliveMonsterList = Manager_Monster.Instance.AliveMonsterList;
        //    for (int i = 0; i < aliveMonsterList.Count; i++)
        //    {
        //        aliveMonsterList[i].SetWalkAnimationSpeed(StageLevel);
        //    }
        //    Character_Player.Instance.SetWalkAnimationSpeed(StageLevel);
        //}
    }

    public void EndStage()
    {
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        
        if (_elapsedTime >= _levelUpInterval)
        {
            LevelUp();
            _elapsedTime = 0f;
        }
    }
}
