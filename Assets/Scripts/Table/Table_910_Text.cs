using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TextData
{
    public int Index;
    public string Kor;
    public string Eng;
}

public class Table_910_Text : TableParser<Table_910_Text, TextData>
{
    protected override void ReadData(string[] _datas)
    {
        for (int i = 2; i < _datas.Length; i++)
        {
            string[] lineData = _datas[i].Split(",");
            TextData Data;
            Data.Index = int.Parse(lineData[0]);
            Data.Kor = lineData[1];
            Data.Eng = lineData[2];
            dataList.Add(Data);
        }
    }
}
