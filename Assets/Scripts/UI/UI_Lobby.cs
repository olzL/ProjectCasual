using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Lobby : UI_Base
{
    [SerializeField] TextMeshProUGUI _startButtonText;

    protected override void Start()
    {
        base.Start();
    }

    protected override void TextInit() 
    {
        _startButtonText.text = TextLoader.Instance.GetText(91000004);
    }

    void Update()
    {
        
    }
}
