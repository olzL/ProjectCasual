using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Stage : UI_Base
{
    #region UI Text
    [SerializeField] TextMeshProUGUI _attackButtonText;
    [SerializeField] TextMeshProUGUI _jumpButtonText;
    [SerializeField] TextMeshProUGUI _stageLevelText;
    [SerializeField] TextMeshProUGUI _frameRateText;
    [SerializeField] TextMeshProUGUI _scoreText;
    [SerializeField] TextMeshProUGUI _PauseTitleName;
    #endregion

    [SerializeField] GameObject _pausePanelObj;

    private Manager_Stage _stageManager;

    // fps 테스트용
    float elapsedTime;

    private void Awake()
    {
        _stageManager = Manager_Stage.Instance;
    }

    protected override void Start()
    {
        base.Start();
        _stageManager.LevelUpAction += TextInit;
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > 0.3f)
        {
            FrameRateDisplay();
            elapsedTime = 0.0f;
        }
        _scoreText.text = Manager_Stage.Instance.Score.ToString();
    }

    protected override void TextInit()
    {
        _stageLevelText.text = string.Format(TextLoader.Instance.GetText(91000001), Manager_Stage.Instance.StageLevel);
        _attackButtonText.text = TextLoader.Instance.GetText(91000002);
        _jumpButtonText.text = TextLoader.Instance.GetText(91000004);
        _PauseTitleName.text = TextLoader.Instance.GetText(91000006);
    }

    // fps 테스트용
    private void FrameRateDisplay()
    {
        float fps = 1.0f / Time.deltaTime;
        float ms = Time.deltaTime * 1000.0f;
        _frameRateText.text = string.Format("{0:N1} FPS ({1:N1}ms)", fps, ms);
    }

    public void PauseButtonClick()
    {
        _stageManager.Pause();
        _pausePanelObj.SetActive(true);
    }

    public void PlayButtonClick()
    {
        _stageManager.Play();
        _pausePanelObj.SetActive(false);
    }

    public void HomeButtonClick()
    {
        _stageManager.EndStage();
    }

    public void VolumeButtonClick()
    {

    }
}
