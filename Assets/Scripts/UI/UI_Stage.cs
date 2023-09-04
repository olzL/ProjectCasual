using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Stage : UI_Base
{
    #region UI Text
    [SerializeField] TextMeshProUGUI _attackButtonText;
    [SerializeField] TextMeshProUGUI _jumpButtonText;
    [SerializeField] TextMeshProUGUI _exitButtonText;
    [SerializeField] TextMeshProUGUI _stageLevelText;
    [SerializeField] TextMeshProUGUI _rameRateText;
    #endregion

    // fps 테스트용
    float elapsedTime;

    protected override void Start()
    {
        base.Start();
        Manager_Stage.Instance.LevelInit += TextInit;
    }

    protected override void TextInit()
    {
        _stageLevelText.text = string.Format(TextLoader.Instance.GetText(91000001), Manager_Stage.Instance.Level);
        _attackButtonText.text = TextLoader.Instance.GetText(91000002);
        _exitButtonText.text = TextLoader.Instance.GetText(91000003);
        _jumpButtonText.text = TextLoader.Instance.GetText(91000004);
    }

    // fps 테스트용
    private void FrameRateDisplay()
    {
        float fps = 1.0f / Time.deltaTime;
        float ms = Time.deltaTime * 1000.0f;
        _rameRateText.text = string.Format("{0:N1} FPS ({1:N1}ms)", fps, ms);
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.3f)
        {
            FrameRateDisplay();
            elapsedTime = 0.0f;
        }
    }
}
