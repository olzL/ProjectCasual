using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoader : SingleTon<TextLoader>
{
    public string GetText(int index)
    {
        // �ٱ��� ���� �߰�
        switch (Manager_Setting.Instance.Language)
        {
            case ELanguageType.Kor: return Table_910_Text.Instance.DataDic[index].Kor;
            case ELanguageType.Eng: return Table_910_Text.Instance.DataDic[index].Eng;
            default: return "null";
        }
    }
}
