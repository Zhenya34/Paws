using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelAvailability : MonoBehaviour
{
    [SerializeField] private int _unlockedLevelIndex = 0;
    [SerializeField] private int _unlockedCrossIndex = 0;
    [SerializeField] private int _unlockedTicksIndex = 0;
    [SerializeField] private GameObject[] _levelButtons;
    [SerializeField] private GameObject[] _crosses;
    [SerializeField] private GameObject[] _ticks;

    private void Awake()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("NoDelete");

        if (gameObjects.Length > 1)
        {
            for (int i = 0; i < gameObjects.Length - 1; i++)
            {
                Destroy(gameObjects[i]);
            }
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadLevelAvailability();
        ActivateUnlockedLevels();
    }

    public void UnlockNextLevel()
    {
        if (_unlockedLevelIndex < _levelButtons.Length - 1)
        {
            _unlockedLevelIndex++;
            _unlockedCrossIndex++;
            _unlockedTicksIndex++;
            SaveLevelAvailability();
        }
    }

    private void LoadLevelAvailability()
    {
        _unlockedLevelIndex = PlayerPrefs.GetInt("UnlockedLevelIndex", 0);
        _unlockedCrossIndex = PlayerPrefs.GetInt("UnlockedCrossIndex", 0);
        _unlockedTicksIndex = PlayerPrefs.GetInt("UnlockedTicksIndex", 0);

        for (int i = 0; i < _levelButtons.Length; i++)
        {
            _levelButtons[i].SetActive(i <= _unlockedLevelIndex);
        }

        for (int i = 0; i < _crosses.Length; i++)
        {
            _crosses[i].SetActive(i >= _unlockedCrossIndex);
        }

        for (int i = 0; i < _ticks.Length; i++)
        {
            _ticks[i].SetActive(i <= _unlockedTicksIndex);
        }
    }

    private void SaveLevelAvailability()
    {
        PlayerPrefs.SetInt("UnlockedLevelIndex", _unlockedLevelIndex);
        PlayerPrefs.SetInt("UnlockedCrossIndex", _unlockedCrossIndex);
        PlayerPrefs.SetInt("UnlockedTicksIndex", _unlockedTicksIndex);
        PlayerPrefs.Save();
    }

    public static void UnlockNextLevelStatic()
    {
        LevelAvailability levelAvailability = FindObjectOfType<LevelAvailability>();
        if (levelAvailability != null)
        {
            levelAvailability.UnlockNextLevel();
        }
    }

    public void ActivateUnlockedLevels()
    {
        if (SceneManager.GetActiveScene().name == "MainScene")
        {
            for (int i = 0; i < _levelButtons.Length; i++)
            {
                _levelButtons[i].SetActive(i <= _unlockedLevelIndex);
            }

            for (int i = 0; i < _crosses.Length; i++)
            {
                _crosses[i].SetActive(i >= _unlockedCrossIndex);
            }

            for (int i = 0; i < _ticks.Length; i++)
            {
                _ticks[i].SetActive(i <= _unlockedTicksIndex);
            }
        }
    }
}