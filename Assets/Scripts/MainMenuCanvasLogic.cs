using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuCanvasLogic : MonoBehaviour
{
    private readonly string _telegramUsername = "Zhenyazhnr_dev";

    public GameObject MainMenuUI;
    public GameObject LevelPanelUI;
    public GameObject statsButton;
    public GameObject settingsButton;
    public GameObject settingsPanel;
    public GameObject statsPanel;
    public GameObject controlsButtonOn;
    public GameObject controlsButtonOFF;
    public GameObject musicButtonON;
    public GameObject musicButtonOFF;
    public GameObject soundButtonON;
    public GameObject soundButtonOFF;

    static public int countOfCake;

    public void OpenLevelPanel()
    {
        MainMenuUI.SetActive(false);
        LevelPanelUI.SetActive(true);
    }

    public void OpenMainMenuSprite()
    {
        MainMenuUI.SetActive(true);
        LevelPanelUI.SetActive(false);
    }

    public void OpenStatsPanel()
    {
        statsButton.SetActive(false);
        statsPanel.SetActive(true);
        settingsButton.SetActive(false);
    }

    public void CloseStatsPanel()
    {
        statsButton.SetActive(true);
        statsPanel.SetActive(false);
        settingsButton.SetActive(true);
    }

    public void OpenSettingsPanel()
    {
        settingsButton.SetActive(false);
        settingsPanel.SetActive(true);
        statsButton.SetActive(false);
    }

    public void CloseSettingsPanel()
    {
        settingsButton.SetActive(true);
        settingsPanel.SetActive(false);
        statsButton.SetActive(true);
    }

    public void HideControls()
    {
        controlsButtonOn.SetActive(false);
        controlsButtonOFF.SetActive(true);
    }

    public void IncludeControls()
    {
        controlsButtonOn.SetActive(true);
        controlsButtonOFF.SetActive(false);
    }

    public void SwitchOnMusicButton()
    {
        musicButtonON.SetActive(true);
        musicButtonOFF.SetActive(false);
    }

    public void SwitchOffMusicButton()
    {
        musicButtonON.SetActive(false);
        musicButtonOFF.SetActive(true);
    }

    public void SwitchOnSoundButton()
    {
        soundButtonON.SetActive(true);
        soundButtonOFF.SetActive(false);
    }

    public void SwitchOffSoundButton()
    {
        soundButtonON.SetActive(false);
        soundButtonOFF.SetActive(true);
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenOwnTelegram()
    {
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
