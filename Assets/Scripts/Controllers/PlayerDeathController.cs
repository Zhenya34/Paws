using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    [SerializeField] private LevelSoundManager _levelSoundManager;
    private bool _isAlreadyDead = false;

    private void Update()
    {
        if (transform.position.y <= -8f)
        {
            HandlePlayerDeath();
        }
    }

    public void HandlePlayerDeath()
    {
        if (!_isAlreadyDead)
        {
            _isAlreadyDead = true;
            GameManager._countOfDeaths++;
            GameManager.SaveGameData();
            _levelSoundManager.PlaySoundOfDead();
        }
    }
}
