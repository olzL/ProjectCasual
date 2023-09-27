using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Manager_Game : MonoSingleton<Manager_Game>
{
    [SerializeField] TextMeshProUGUI langaueText;

    public int GameMode { get { return _gameMode; } }
    private int _gameMode;

    private void Awake()
    {
        // 테스트용
        langaueText.text = "현재 접속 언어: " + Application.systemLanguage.ToString();
    }

    private void Start()
    {
//#if UNITY_IOS || UNITY_ANDROID
        Application.targetFrameRate = 60;
        OnDemandRendering.renderFrameInterval = 1;
//#endif
    }

    public void StartInfiniteStage()
    {
        _gameMode = 1;
        SceneManager.LoadScene("Main");
    }

    public void StartChallengeStage()
    {
        _gameMode = 2;
        SceneManager.LoadScene("Main");
    }
}
