using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCanvasLogic : MonoBehaviour
{
    [SerializeField] private GameObject _pauseUI;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private GameObject _soundButton;
    [SerializeField] private LevelSoundManager _levelCanvasSound;

    public void HidePausePanel()
    {
        _pauseUI.SetActive(false);
        _pauseButton.SetActive(true);
        _soundButton.SetActive(false);
        Time.timeScale = 1f;
        _levelCanvasSound.PlayPressingButtonSound();
    }

    public void ShowPausePanel()
    {
        _pauseUI.SetActive(true);
        _pauseButton.SetActive(false);
        _soundButton.SetActive(true);
        Time.timeScale = 0f;
        _levelCanvasSound.PlayPauseButtonSound();
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }
} 
