using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_Button : MonoBehaviour, IPointerDownHandler
{
    // onClick으로 하면 버튼을 눌렀다 뗄 때 실행되서 누를 때 바로 실행되도록 추가
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
