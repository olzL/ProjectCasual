using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Stage : UI_Base
{
    #region UI Text
    [SerializeField] TextMeshProUGUI _AttackButtonText;
    [SerializeField] TextMeshProUGUI _ExitButtonText;
    [SerializeField] TextMeshProUGUI _StageLevelText;
    #endregion

    protected override void Start()
    {
        base.Start();
        Manager_Stage.Instance.LevelInit += TextInit;
    }

    protected override void TextInit()
    {
        _StageLevelText.text = string.Format(TextLoader.Instance.GetText(91000001), Manager_Stage.Instance.Level);
        _AttackButtonText.text = TextLoader.Instance.GetText(91000002);
        _ExitButtonText.text = TextLoader.Instance.GetText(91000003);
    }
}
