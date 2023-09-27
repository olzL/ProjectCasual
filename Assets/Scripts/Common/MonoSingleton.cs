using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance != null)
            {
                return _instance;
            }

            _instance = (T)FindObjectOfType(typeof(T));

            if (_instance == null)
            {
                var singletonObj = new GameObject();
                _instance = singletonObj.AddComponent<T>();
                singletonObj.name = typeof(T).ToString();
            }

            return _instance;
        }
    }
}
