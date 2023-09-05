using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomRandom
{
    /// <summary>
    /// 랜덤값 추출(만분율)
    /// </summary>
    public static int Random10000(int[] valueArray, int[] ratioArray)
    {
        int random = Random.Range(0, 10000);
        int value = 0;
        for (int i = 0; i < valueArray.Length; i++)
        {
            if (ratioArray[i] > random)
            {
                value = valueArray[i];
                break;
            }
            else
            {
                random -= ratioArray[i];
            }
        }

        return value;
    }
}
