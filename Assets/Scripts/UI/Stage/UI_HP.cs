using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HP : MonoBehaviour
{
    [SerializeField]
    Image Hpbar;
    float maxHp;

    private void Start()
    {
        maxHp = Character_Player.Instance.Hp;
    }

    private void Update()
    {
        Hpbar.fillAmount = Character_Player.Instance.Hp / maxHp;
    }
}
