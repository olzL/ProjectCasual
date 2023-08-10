using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> where T : class, new()
{
    private static T inst;
    public SingleTon() 	// 생성자에서 할 일이 없는 경우 작성하지 않아도 됨
    {

    }
    public static T instance
    {
        get
        {
            if (inst == null)
                inst = new T();
            return inst;
        }
    }
}
