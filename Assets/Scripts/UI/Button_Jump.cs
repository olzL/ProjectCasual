using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_Jump: UI_Button
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        Character_Player.Instance.JumpClick();
    }
}
