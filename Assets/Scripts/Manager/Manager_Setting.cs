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
        // ���߿� ������ �°� ����
        Language = ELanguageType.Kor;
    }

    void Start()
    {

    }

    
    // �ӽ�
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
