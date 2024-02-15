using UnityEngine;

public class PlayerDeathController : MonoBehaviour
{
    private int _countOfDeath = 0;
    public LevelCanvasLogic levelCanvasLogic;

    void Update()
    {
        if (transform.position.y <= -8f)
        {
            HandlePlayerDeath();
        }
    }

    public void HandlePlayerDeath()
    {
        _countOfDeath++;
        Destroy(gameObject);
        levelCanvasLogic.ReloadScene();
    }
}
