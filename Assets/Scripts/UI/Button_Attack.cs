using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Button_Attack : UI_Button
{
    public override void OnPointerDown(PointerEventData eventData)
    {
        Character_Player.Instance.AttackClick();
    }
}
