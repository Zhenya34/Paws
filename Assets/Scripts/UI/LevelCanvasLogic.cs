using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCanvasLogic : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject soundButton;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip jumpSound;

    public void HidePausePanel()
    {
        pauseUI.SetActive(false);
        pauseButton.SetActive(true);
        soundButton.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ShowPausePanel()
    {
        pauseUI.SetActive(true);
        pauseButton.SetActive(false);
        soundButton.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
