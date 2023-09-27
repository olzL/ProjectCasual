using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextLoader : SingleTon<TextLoader>
{
    public string GetText(int index)
    {
        SystemLanguage language = Application.systemLanguage;

        // 다국어 조건 추가
        switch (language)
        {
            case SystemLanguage.Korean: return Table_910_Text.Instance.DataDic[index].Ko;
            case SystemLanguage.Japanese: return Table_910_Text.Instance.DataDic[index].Ja;
            case SystemLanguage.ChineseSimplified: return Table_910_Text.Instance.DataDic[index].Zh_CN;
            case SystemLanguage.ChineseTraditional: return Table_910_Text.Instance.DataDic[index].Zh_TW;
            default: return Table_910_Text.Instance.DataDic[index].En;
        }
    }
}
