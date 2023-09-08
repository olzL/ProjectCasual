using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Stage : UI_Base
{
    #region UI Text
    [SerializeField] TextMeshProUGUI _attackButtonText;
    [SerializeField] TextMeshProUGUI _jumpButtonText;
    [SerializeField] TextMeshProUGUI _stageLevelText;
    [SerializeField] TextMeshProUGUI _frameRateText;
    [SerializeField] TextMeshProUGUI _scoreText;

    // Pause Panel
    [SerializeField] TextMeshProUGUI _pauseTitleName;

    // GameOver Panel
    [SerializeField] TextMeshProUGUI _gameOverTitleName;
    [SerializeField] TextMeshProUGUI _aliveTimeText;
    [SerializeField] TextMeshProUGUI _killAmountText;
    [SerializeField] TextMeshProUGUI _totalScoreText;
    [SerializeField] TextMeshProUGUI _adDescText;
    #endregion

    [SerializeField] GameObject _pausePanelObj;
    [SerializeField] GameObject _gameOverPanelObj;
    [SerializeField] Image Hpbar;

    // fps 테스트용
    float elapsedTime;

    protected override void Start()
    {
        base.Start();

        Manager_Stage.Instance.LevelUpAction += TextInit;
        Character_Player.Instance.DeathAction += ShowGameOverPanel;
    }

    private void Update()
    {
        Hpbar.fillAmount = (float)Character_Player.Instance.CurHp / Character_Player.Instance.MaxHp;
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
        _pauseTitleName.text = TextLoader.Instance.GetText(91000006);
    }

    private void ShowGameOverPanel()
    {
        int aliveTimeMin = Manager_Stage.Instance.AliveTime / 60;
        int aliveTimeSec = Manager_Stage.Instance.AliveTime % 60;

        _gameOverTitleName.text = TextLoader.Instance.GetText(91000007);
        _killAmountText.text = string.Format(TextLoader.Instance.GetText(91000009), Manager_Stage.Instance.KillAmount);
        _totalScoreText.text = string.Format(TextLoader.Instance.GetText(91000010), Manager_Stage.Instance.Score);
        _adDescText.text = TextLoader.Instance.GetText(91000011);
        _aliveTimeText.text = string.Format(TextLoader.Instance.GetText(91000008), aliveTimeMin, aliveTimeSec);

        _gameOverPanelObj.SetActive(true);
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
        Manager_Stage.Instance.Pause();
        _pausePanelObj.SetActive(true);
    }

    public void PlayButtonClick()
    {
        Manager_Stage.Instance.Play();
        _pausePanelObj.SetActive(false);
    }

    public void HomeButtonClick()
    {
        Manager_Stage.Instance.EndStage();
    }

    public void VolumeButtonClick()
    {

    }

    public void AdButtonClick()
    {
        _gameOverPanelObj.SetActive(false);
        Character_Player.Instance.PlayAnimation(5);
    }
}
