using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct TextData
{
    public int Index;
    public string Ko;       // �ѱ���
    public string En;       // ����
    public string Ja;       // �Ϻ���
    public string Zh_CN;    // �߱���(��ü)
    public string Zh_TW;    // �߱���(��ü)
}

public class Table_910_Text : TableParser<Table_910_Text, TextData>
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
            TextData Data;
            Data.Index = int.Parse(lineData[0]);
            Data.Ko = lineData[1];
            Data.En = lineData[2];
            Data.Ja = lineData[3];
            Data.Zh_CN = lineData[4];
            Data.Zh_TW = lineData[5];
            dataList.Add(Data);
            dataDic.Add(Data.Index, Data);
        }
    }
}
