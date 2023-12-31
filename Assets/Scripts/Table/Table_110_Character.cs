using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CharacterData
{
    public int Index;
    public int Name;
    public int HpBase;
    public int HpAdd;
    public int AtkBase;
    public int AtkAdd;
    public float CriChance;
    public float ScaleX;
    public float ScaleY;
    public string AnimatorName;
    public ECharacterType Type;
}

public enum ECharacterType
{
    None,
    Character,
    Monster,
    Obstacle
}

public class Table_110_Character : TableParser<Table_110_Character, CharacterData>
{
    protected override void ReadData(string[] _datas)
    {
        for (int i = 2; i < _datas.Length; i++)
        {
            string[] lineData = _datas[i].Split(",");
            if (lineData[0] == "")
            {
                continue;
            }
            CharacterData Data;
            Data.Index = int.Parse(lineData[0]);
            Data.Name = int.Parse(lineData[1]);
            Data.HpBase = int.Parse(lineData[2]);
            Data.HpAdd = int.Parse(lineData[3]);
            Data.AtkBase = int.Parse(lineData[4]);
            Data.AtkAdd = int.Parse(lineData[5]);
            Data.CriChance = float.Parse(lineData[6]);
            Data.ScaleX = float.Parse(lineData[7]);
            Data.ScaleY = float.Parse(lineData[8]);
            Data.AnimatorName = lineData[9];
            Data.Type = (ECharacterType)Enum.Parse(typeof(ECharacterType), lineData[10]);
            dataList.Add(Data);
            dataDic.Add(Data.Index, Data);
        }
    }
}
