using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    //private static bool isDisable = false;
    //private static object lockObj = new object();
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
                singletonObj.name = typeof(T).ToString() + " (Singleton)";
            }

            return _instance;


            //if (isDisable)
            //{
            //    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +"' already destroyed. Returning null.");
            //    return null;
            //}

            //lock (lockObj)
            //{
            //    if (_instance == null)
            //    {
            //        _instance = (T)FindObjectOfType(typeof(T));

            //        if (_instance == null)
            //        {
            //            var singletonObj = new GameObject();
            //            _instance = singletonObj.AddComponent<T>();
            //            singletonObj.name = typeof(T).ToString() + " (Singleton)";
            //        }
            //    }

            //    return _instance;
            //}
        }
    }

    //private void OnApplicationQuit()
    //{
    //    isDisable = true;
    //}


    //private void OnDestroy()
    //{
    //    isDisable = true;
    //}
}
