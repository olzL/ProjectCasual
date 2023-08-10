using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_Attack : Button_Base
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        Character_Player.Instance.Attack();
    }
}
