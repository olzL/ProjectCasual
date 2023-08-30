using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct GlobalValueData
{
    public int Index;
    public int IntValue;
    public float FloatValue;
}

public class Table_101_GlobalValue : TableParser<Table_101_GlobalValue, GlobalValueData>
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
            GlobalValueData Data;
            Data.Index = int.Parse(lineData[0]);
            Data.IntValue = int.Parse(lineData[2]);
            Data.FloatValue = float.Parse(lineData[3]);
            dataList.Add(Data);
            dataDic.Add(Data.Index, Data);
        }
    }
}
