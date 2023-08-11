using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ELanguageType
{
    Kor,
    Eng
}

public class Manager_Setting : MonoSingleton<Manager_Setting>
{
    public ELanguageType Language { get; private set; }
    public Action TextInit;

    private void Awake()
    {
        DontDestroyOnLoad(this);
        // 나중에 국가에 맞게 변경
        Language = ELanguageType.Kor;
    }

    void Start()
    {

    }

    
    // 임시
    public void LanguageChange(bool isKor)
    {
        if (isKor)
        {
            Language = ELanguageType.Kor;
        }
        else
        {
            Language = ELanguageType.Eng;
        }
        TextInit();
    }
    //public void LanguageChange(ELanguageType type)
    //{
    //    Language = type;
    //    TextInit();
    //}

    void Update()
    {
        
    }
}
