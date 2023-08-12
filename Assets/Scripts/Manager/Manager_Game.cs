using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class Manager_Game : MonoSingleton<Manager_Game>
{
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
    }

    public void StartStage()
    {
        SceneManager.LoadScene(1);
    }
}
