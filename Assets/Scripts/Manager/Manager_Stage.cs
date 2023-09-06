using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Stage : MonoSingleton<Manager_Stage>
{
    public float StageSpeed { get { return _stageSpeed; } }   // 맵 및 몬스터 이동 속도
    public int StageLevel { get { return _stageLevel; } }     // 스테이지 레벨
    public Action LevelInit;                        // 레벨업 시 실행될 함수들

    private float _elapsedTime;
    private float _stageSpeed;
    private int _stageLevel;
    private float _levelUpInterval;

    private Dictionary<int, GlobalValueData> _globalValueDic;
    private Dictionary<int, StageData> _stageDataDic;

    private void Start()
    {
        _globalValueDic = Table_101_GlobalValue.Instance.DataDic;
        _stageDataDic = Table_210_Stage.Instance.DataDic;
        StageInit(1);
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

    private void StageInit(int level)
    {
        _stageLevel = level;
        _stageSpeed = _stageDataDic[StageLevel].Speed;
        _levelUpInterval = _stageDataDic[StageLevel].FinishTime;
        Manager_Background.Instance.ChangeBackground(_stageDataDic[level].Background);
    }

    private void LevelUp()
    {
        StageInit(++_stageLevel);
        LevelInit();
    }

    public void EndStage()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }
}
