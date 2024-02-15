using UnityEngine;

public class TrapController : MonoBehaviour
{
    public PlayerDeathController playerDeathController;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerDeathController.HandlePlayerDeath();
        }            
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerDeathController.HandlePlayerDeath();
        }
    }
}
