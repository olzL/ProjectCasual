using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTon<T> where T : class, new()
{
    private static T inst;
    public SingleTon() 	// �����ڿ��� �� ���� ���� ��� �ۼ����� �ʾƵ� ��
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
