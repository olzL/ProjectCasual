using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableParser<T,Q> where T : class, new() where Q : struct
{
    static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new T();
            }
            return instance;
        }
    }

    protected List<Q> dataList;
    public List<Q> DataList
    {
        get { return dataList; }
    }

    protected Dictionary<int, Q> dataDic;
    public Dictionary<int, Q> DataDic
    {
        get { return dataDic; }
    }

    public void LoadData(string _fileName)
    {
        dataList = new List<Q>();
        dataDic = new Dictionary<int, Q>();
        TextAsset textAsset = Resources.Load<TextAsset>("Table/" + _fileName);
        ReadData(textAsset.text.Split("\r\n"));
    }

    protected virtual void ReadData(string[] _datas){ }
}