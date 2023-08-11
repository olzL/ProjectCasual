using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoader : SingleTon<TextLoader>
{
    public string GetText(int index)
    {
        // 다국어 조건 추가
        switch (Manager_Setting.Instance.Language)
        {
            case ELanguageType.Kor: return Table_910_Text.Instance.DataDic[index].Kor;
            case ELanguageType.Eng: return Table_910_Text.Instance.DataDic[index].Eng;
            default: return "null";
        }
    }
}
