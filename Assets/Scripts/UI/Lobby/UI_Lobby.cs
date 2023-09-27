using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Lobby : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _startButtonText;

    private void Start()
    {
        TextInit();
    }

    private void TextInit() 
    {
        _startButtonText.text = TextLoader.Instance.GetText(91000005);
    }

    void Update()
    {
        
    }
}
