using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.TextCore.Text;

public class Manager_Game : MonoSingleton<Manager_Game>
{
    [SerializeField] Character_Lobby _character;
    public Action FirstLoginAction;
    public int CurCharacterIndex { get { return _curCharacterIndex; } }

    private int _curCharacterIndex;

    // �׽�Ʈ��
    [SerializeField] TextMeshProUGUI _langaueText;

    private void Awake()
    {
        // �׽�Ʈ��
        _langaueText.text = "���� ���� ���: " + Application.systemLanguage.ToString();
    }

    private void Start()
    {
#if UNITY_IOS || UNITY_ANDROID
        Application.targetFrameRate = 60;
        OnDemandRendering.renderFrameInterval = 1;
#endif

        if (IsFirstLogin())
        {
            Debug.Log("ù �α���");
            PlayerPrefs.SetInt("CurCharacterIndex", 11000001);
        }

        CharacterChange();
    }

    public void CharacterChange()
    {
        _curCharacterIndex = PlayerPrefs.GetInt("CurCharacterIndex");
        _character.Init(_curCharacterIndex);
    }

    private bool IsFirstLogin()
    {
        int isFirst = PlayerPrefs.GetInt("FirstLogin");
        if (isFirst == 1)
        {
            return false;
        }
        else
        {
            PlayerPrefs.SetInt("FirstLogin", 1);
            //FirstLoginAction();
            return true;
        }
    }

    public void DeleteAllDatas()
    {
        PlayerPrefs.DeleteAll();
    }
}
