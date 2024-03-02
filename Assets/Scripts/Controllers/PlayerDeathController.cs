using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    [SerializeField] private LevelSoundManager _levelSoundManager;
    private bool _isAlreadyDead = false;
    static private int _countOfDeath = 0;

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
            _countOfDeath++;
            _levelSoundManager.PlaySoundOfDead();
        }
    }
}
