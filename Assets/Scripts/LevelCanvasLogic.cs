using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCanvasLogic : MonoBehaviour
{
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private GameObject pauseButton;
    [SerializeField] private GameObject soundButton;

    public void HidePausePanel()
    {
        pauseUI.SetActive(false);
        pauseButton.SetActive(true);
        soundButton.SetActive(false);
    }

    public void ShowPausePanel()
    {
        pauseUI.SetActive(true);
        pauseButton.SetActive(false);
        soundButton.SetActive(true);
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
