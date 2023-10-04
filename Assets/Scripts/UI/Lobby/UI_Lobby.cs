using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI_Lobby : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _startButtonText;
    [SerializeField] GameObject _charSelectPanelObj;
    [SerializeField] GameObject _defaultPanelObj;

    [SerializeField] Button _charSelectButton;

    GameObject _curShowPanel;

    private void Start()
    {
        TextInit();
        _curShowPanel = _defaultPanelObj;
        ShowPaenl(_curShowPanel);
    }

    private void TextInit() 
    {
        _startButtonText.text = TextLoader.Instance.GetText(91000005);
    }

    void Update()
    {
        
    }

    public void StartInfiniteStage()
    {
        SceneManager.LoadScene("Main");
    }

    private void ShowPaenl(GameObject panel)
    {
        _curShowPanel.SetActive(false);
        panel.SetActive(true);
        _curShowPanel = panel;
    }

    public void CharacterSelectButtonClick()
    {
        ShowPaenl(_charSelectPanelObj);
    }

    public void SelectButtonClick()
    {
        ShowPaenl(_defaultPanelObj);
    }
}
