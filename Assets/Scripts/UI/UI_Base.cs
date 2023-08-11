using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UI_Base : MonoBehaviour
{
    protected abstract void TextInit();

    protected virtual void Start()
    {
        Manager_Setting.Instance.TextInit += TextInit;
        TextInit();
    }
}
