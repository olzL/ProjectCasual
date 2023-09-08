using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Manager_Game : MonoSingleton<Manager_Game>
{
    public int GameMode { get { return _gameMode; } }
    private int _gameMode;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        TableLoadAll();
    }

    private void Start()
    {
#if UNITY_IOS || UNITY_ANDROID
        Application.targetFrameRate = 60;
        OnDemandRendering.renderFrameInterval = 1;
#endif
    }

    void Update()
    {
        
    }

    private void TableLoadAll()
    {
        Table_110_Character.Instance.LoadData("110_Character");
        Table_910_Text.Instance.LoadData("910_Text");
        Table_101_GlobalValue.Instance.LoadData("101_GlobalValue");
        Table_210_Stage.Instance.LoadData("210_Stage");
    }

    public void StartInfiniteStage()
    {
        _gameMode = 1;
        SceneManager.LoadScene(1);
    }

    public void StartChallengeStage()
    {
        _gameMode = 2;
        SceneManager.LoadScene(1);
    }
}
