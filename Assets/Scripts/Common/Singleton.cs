using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SingleTon<T> where T : class, new()
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
                _instance = new T();
            return _instance;
        }
    }
}
