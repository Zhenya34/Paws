using UnityEngine;

public class LevelAvailability : MonoBehaviour
{
    [SerializeField] private int _unlockedLevelIndex = 0;
    [SerializeField] private GameObject[] _levelButtons;

    private void Start()
    {
        LoadLevelAvailability();
    }

    public void UnlockNextLevel()
    {
        if (_unlockedLevelIndex < _levelButtons.Length - 1)
        {
            _unlockedLevelIndex++;
            _levelButtons[_unlockedLevelIndex].SetActive(true);
            SaveLevelAvailability();
        }
    }

    private void LoadLevelAvailability()
    {
        _unlockedLevelIndex = PlayerPrefs.GetInt("UnlockedLevelIndex", 0);
        for (int i = 0; i <= _unlockedLevelIndex; i++)
        {
            _levelButtons[i].SetActive(true);
        }
    }

    private void SaveLevelAvailability()
    {
        PlayerPrefs.SetInt("UnlockedLevelIndex", _unlockedLevelIndex);
        PlayerPrefs.Save();
    }
}