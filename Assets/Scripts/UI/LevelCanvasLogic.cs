using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCanvasLogic : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _soundButton;
    [SerializeField] private LevelSoundManager _levelCanvasSound;
    [SerializeField] private TMP_Text _deathsText;
    [SerializeField] private AudioSource finalSceneAudioSource;

    private void Start()
    {
        UpdateDeathsText();
    }

    public void HidePausePanel()
    {
        _pauseUI.SetActive(false);
        _pauseButton.SetActive(true);
        _soundButton.SetActive(false);
        Time.timeScale = 1f;
        _levelCanvasSound.PlayPressingButtonSound();
        UpdateDeathsText();
        if (finalSceneAudioSource != null)
        {
            finalSceneAudioSource.UnPause();
            finalSceneAudioSource.Play();
        }
        
    }

    public void ShowPausePanel()
    {
        _pauseUI.SetActive(true);
        _pauseButton.SetActive(false);
        _soundButton.SetActive(true);
        Time.timeScale = 0f;
        _levelCanvasSound.PlayPauseButtonSound();
        UpdateDeathsText();
        if (finalSceneAudioSource != null)
        {
            finalSceneAudioSource.Pause();
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void ReloadScene()
    {
        UpdateDeathsText();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    private void UpdateDeathsText()
    {
        if (_deathsText != null)
        {
            _deathsText.text = GameManager.CountOfDeaths.ToString();
        }
    }
} 
