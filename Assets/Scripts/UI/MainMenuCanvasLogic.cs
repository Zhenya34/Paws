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

    [SerializeField] private LevelSoundManager _levelSoundManager;
    [SerializeField] private SettingsManager _settingsManager;

    public void OpenLevelPanel()
    {
        _MainMenuUI.SetActive(false);
        _LevelPanelUI.SetActive(true);
        _levelSoundManager.PlayPressingButtonSound();
    }

    public void OpenMainMenuSprite()
    {
        _MainMenuUI.SetActive(true);
        _LevelPanelUI.SetActive(false);
        _levelSoundManager.PlayPressingButtonSound();
    }

    public void OpenStatsPanel()
    {
        _statsButton.SetActive(false);
        _statsPanel.SetActive(true);
        _settingsButton.SetActive(false);
        _levelSoundManager.PlayPressingButtonSound();
    }

    public void CloseStatsPanel()
    {
        _statsButton.SetActive(true);
        _statsPanel.SetActive(false);
        _settingsButton.SetActive(true);
        _levelSoundManager.PlayPressingButtonSound();
    }

    public void OpenSettingsPanel()
    {
        _settingsButton.SetActive(false);
        _settingsPanel.SetActive(true);
        _statsButton.SetActive(false);
        _levelSoundManager.PlayPressingButtonSound();
    }

    public void CloseSettingsPanel()
    {
        _settingsButton.SetActive(true);
        _settingsPanel.SetActive(false);
        _statsButton.SetActive(true);
        _levelSoundManager.PlayPressingButtonSound();
    }

    public void HideControls()
    {
        _settingsManager.DeactivateGlobalControls();
        _controlsButtonOn.SetActive(false);
        _controlsButtonOFF.SetActive(true);
        _levelSoundManager.PlayMusicButtonClip();
    }

    public void IncludeControls()
    {
        _settingsManager.ActivateGlobalControls();
        _controlsButtonOn.SetActive(true);
        _controlsButtonOFF.SetActive(false);
        _levelSoundManager.PlayMusicButtonClip();
    }

    public void SwitchOnMusicButton()
    {
        _settingsManager.ActivateGlobalMusic();
        _musicButtonON.SetActive(true);
        _musicButtonOFF.SetActive(false);
        _levelSoundManager.PlayMusicButtonClip();
    }

    public void SwitchOffMusicButton()
    {
        _musicButtonON.SetActive(false);
        _musicButtonOFF.SetActive(true);
        _levelSoundManager.PlayMusicButtonClip();
        _settingsManager.DeactivateGlobalMusic();
    }

    public void SwitchOnSoundButton()
    {
        _settingsManager.ActivateGlobalSound();
        _soundButtonON.SetActive(true);
        _soundButtonOFF.SetActive(false);
        _levelSoundManager.PlayMusicButtonClip();
    }

    public void SwitchOffSoundButton()
    {
        _soundButtonON.SetActive(false);
        _soundButtonOFF.SetActive(true);
        _levelSoundManager.PlayMusicButtonClip();
        _settingsManager.DeactivateGlobalSound();
    }

    public void LoadSceneByName(string sceneName)
    {
        GameManager.SaveGameData();
        _levelSoundManager.PlaySelectedLevelClip();
        StartCoroutine(PlaySoundAndLoadLevel(sceneName));
    }

    private IEnumerator PlaySoundAndLoadLevel(string sceneName)
    {
        yield return new WaitForSeconds(_levelSoundManager._selectedLevelClip.length);
        SceneManager.LoadScene(sceneName);
    }

    public void UpdateMusicButtonSprites(bool isMusicEnabled)
    {
        _musicButtonON.SetActive(isMusicEnabled);
        _musicButtonOFF.SetActive(!isMusicEnabled);
    }

    public void UpdateSoundButtonSprites(bool isSoundEnabled)
    {
        _soundButtonON.SetActive(isSoundEnabled);
        _soundButtonOFF.SetActive(!isSoundEnabled);
    }


    public void OpenOwnTelegram()
    {
        _levelSoundManager.PlayPressingButtonSound();
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
