using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuCanvasLogic : MonoBehaviour
{
    private readonly string _telegramUsername = "Zhenyazhnr_dev";

    [SerializeField] private GameObject _MainMenuUI;
    [SerializeField] private GameObject _LevelPanelUI;
    [SerializeField] private GameObject _statsButton;
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _statsPanel;
    [SerializeField] private GameObject _controlsButtonOn;
    [SerializeField] private GameObject _controlsButtonOFF;
    [SerializeField] private GameObject _musicButtonON;
    [SerializeField] private GameObject _musicButtonOFF;
    [SerializeField] private GameObject _soundButtonON;
    [SerializeField] private GameObject _soundButtonOFF;

    [SerializeField] private MainMenuSoundManager _mainMenuSoundManager;

    static public int countOfCake;

    public void OpenLevelPanel()
    {
        _MainMenuUI.SetActive(false);
        _LevelPanelUI.SetActive(true);
        _mainMenuSoundManager.PlayPressingButtonSound();
    }

    public void OpenMainMenuSprite()
    {
        _MainMenuUI.SetActive(true);
        _LevelPanelUI.SetActive(false);
        _mainMenuSoundManager.PlayClosingSound();
    }

    public void OpenStatsPanel()
    {
        _statsButton.SetActive(false);
        _statsPanel.SetActive(true);
        _settingsButton.SetActive(false);
        _mainMenuSoundManager.PlayPressingButtonSound();
    }

    public void CloseStatsPanel()
    {
        _statsButton.SetActive(true);
        _statsPanel.SetActive(false);
        _settingsButton.SetActive(true);
        _mainMenuSoundManager.PlayClosingSound();
    }

    public void OpenSettingsPanel()
    {
        _settingsButton.SetActive(false);
        _settingsPanel.SetActive(true);
        _statsButton.SetActive(false);
        _mainMenuSoundManager.PlayPressingButtonSound();
    }

    public void CloseSettingsPanel()
    {
        _settingsButton.SetActive(true);
        _settingsPanel.SetActive(false);
        _statsButton.SetActive(true);
        _mainMenuSoundManager.PlayClosingSound();
    }

    public void HideControls()
    {
        _controlsButtonOn.SetActive(false);
        _controlsButtonOFF.SetActive(true);
        _mainMenuSoundManager.PlayMusicButtonClip();
    }

    public void IncludeControls()
    {
        _controlsButtonOn.SetActive(true);
        _controlsButtonOFF.SetActive(false);
        _mainMenuSoundManager.PlayMusicButtonClip();
    }

    public void SwitchOnMusicButton()
    {
        _musicButtonON.SetActive(true);
        _musicButtonOFF.SetActive(false);
        _mainMenuSoundManager.PlayMusicButtonClip();
    }

    public void SwitchOffMusicButton()
    {
        _musicButtonON.SetActive(false);
        _musicButtonOFF.SetActive(true);
        _mainMenuSoundManager.PlayMusicButtonClip();
    }

    public void SwitchOnSoundButton()
    {
        _soundButtonON.SetActive(true);
        _soundButtonOFF.SetActive(false);
        _mainMenuSoundManager.PlayMusicButtonClip();
    }

    public void SwitchOffSoundButton()
    {
        _soundButtonON.SetActive(false);
        _soundButtonOFF.SetActive(true);
        _mainMenuSoundManager.PlayMusicButtonClip();
    }

    public void LoadSceneByName(string sceneName)
    {
        _mainMenuSoundManager.PlaySelectedLevelClip();
        StartCoroutine(PlaySoundAndLoadLevel(sceneName));
    }

    private IEnumerator PlaySoundAndLoadLevel(string sceneName)
    {
        yield return new WaitForSeconds(_mainMenuSoundManager._selectedLevelClip.length);
        SceneManager.LoadScene(sceneName);
    }


    public void OpenOwnTelegram()
    {
        _mainMenuSoundManager.PlayPressingButtonSound();
        try
        {
            Application.OpenURL($"https://t.me/{_telegramUsername}");
        }
        catch (System.Exception ex)
        {
            Debug.LogError($"Failed to open Telegram. {ex.Message}");
        }
    }
}
