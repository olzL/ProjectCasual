using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public struct StageData
{
    public int Level;
    public float FinishTime;
    public int[] SpawnIndex;
    public int[] SpawnRatio;
    public float Speed;
    public string Background;
}

public class Table_210_Stage : TableParser<Table_210_Stage, StageData>
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
            StageData Data;
            Data.SpawnIndex = new int[2];
            Data.SpawnRatio = new int[2];

            Data.Level = int.Parse(lineData[0]);
            Data.FinishTime = float.Parse(lineData[1]);
            Data.SpawnIndex[0] = int.Parse(lineData[2]);
            Data.SpawnRatio[0] = int.Parse(lineData[3]);
            Data.SpawnIndex[1] = int.Parse(lineData[4]);
            Data.SpawnRatio[1] = int.Parse(lineData[5]);
            Data.Speed = float.Parse(lineData[6]);
            Data.Background = lineData[7];
            dataList.Add(Data);
            dataDic.Add(Data.Level, Data);
        }
    }
}
