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
    public double Score { get { return _score; } }     // 스테이지 레벨
    public Action LevelUpAction;                        // 레벨업 시 실행될 함수들

    private float _stageSpeed;
    private int _stageLevel;
    private double _score;

    private int _addTimeScore;
    private int _addKillScore;

    private float _levelUpInterval;     // 레벨업 간격
    private float _levelUpElapsedTime;  // 레벨업 지난 시간

    private float _timeScoreInterval;    // 시간점수 간격
    private float _timeScoreElapsedTime; // 시간점수 지난 시간

    private Dictionary<int, StageData> _stageDataDic;
    private Dictionary<int, GlobalValueData> _globalDataDic;

    private void Awake()
    {
        _stageDataDic = Table_210_Stage.Instance.DataDic;
        _globalDataDic = Table_101_GlobalValue.Instance.DataDic;
        _score = 0;
        _timeScoreInterval = _globalDataDic[10000001].FloatValue;
    }

    private void Start()
    {
        StageInit(1);
    }

    void Update()
    {
        _levelUpElapsedTime += Time.deltaTime;
        if (_levelUpElapsedTime >= _levelUpInterval)
        {
            LevelUp();
            _levelUpElapsedTime = 0f;
        }

        _timeScoreElapsedTime += Time.deltaTime;
        if (_timeScoreElapsedTime >= _timeScoreInterval)
        {
            AddTimeScore();
            _timeScoreElapsedTime = 0f;
        }
    }

    private void StageInit(int level)
    {
        _stageLevel = level;
        _stageSpeed = _stageDataDic[StageLevel].Speed;
        _addTimeScore = _stageDataDic[StageLevel].TimeScore;
        _addKillScore = _stageDataDic[StageLevel].KillScore;
        _levelUpInterval = _stageDataDic[StageLevel].FinishTime;
        Manager_Background.Instance.ChangeBackground(_stageDataDic[level].Background);
    }

    private void LevelUp()
    {
        StageInit(++_stageLevel);
        LevelUpAction();
    }

    public void EndStage()
    {
        SceneManager.LoadScene(0);
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    private void AddTimeScore()
    {
        _score += _addTimeScore;
    }

    public void AddKillScore()
    {
        _score += _addKillScore;
    }
}
