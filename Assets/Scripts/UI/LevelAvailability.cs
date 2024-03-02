using UnityEngine;

public class LevelAvailability : MonoBehaviour
{
    [SerializeField] private int _unlockedLevelIndex = 0;
    [SerializeField] private GameObject[] _levelButtons;

    public void UnlockNextLevel()
    {
        if (_unlockedLevelIndex < _levelButtons.Length - 1)
        {
            _unlockedLevelIndex++;
            _levelButtons[_unlockedLevelIndex].SetActive(true);
        }
    }
}