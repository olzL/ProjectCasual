using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Stage : MonoSingleton<Manager_Stage>
{
    public float StageSpeed { get { return _stageSpeed; } } // �� �� ���� �̵� �ӵ�
    public int StageLevel { get { return _stageLevel; } }   // �������� ����
    public double Score { get { return _score; } }          // �������� ����
    public int KillAmount { get { return _killAmount; } }  // ���� ų Ƚ��
    public int AliveTime { get { return _aliveTime; } }  // ���� �ð�
    public Action LevelUpAction;                            // ������ �� ����� �Լ���

    private float _stageSpeed;
    private int _stageLevel;
    private double _score;

    private int _killAmount;
    private int _aliveTime;
    private float _elapsedTime;

    private int _addTimeScore;
    private int _addKillScore;

    private float _levelUpInterval;     // ������ ����
    private float _timeScoreInterval;    // �ð����� ����

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
        Play();
        _killAmount = 0;
        _aliveTime = 0;
        Character_Player.Instance.DeathAction += Pause;

        StartCoroutine(Timer(LevelUp, _levelUpInterval));
        StartCoroutine(Timer(AddTimeScore, _timeScoreInterval));
    }

    void Update()
    {
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= 1)
        {
            _aliveTime++;
            _elapsedTime = 0f;
        }
    }

    IEnumerator Timer(Action action, float intervalTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(intervalTime);
            action();
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

    public void Play()
    {
        Time.timeScale = 1;
    }

    private void AddTimeScore()
    {
        _score += _addTimeScore;
    }

    public void AddKillScore()
    {
        _killAmount++;
        _score += _addKillScore;
    }
}
