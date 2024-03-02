using UnityEngine;

public class TrapController : MonoBehaviour
{
    [SerializeField] private PlayerDeathController _playerDeathController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerDeathController.HandlePlayerDeath();
        }            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            _playerDeathController.HandlePlayerDeath();
        }
    }
}
