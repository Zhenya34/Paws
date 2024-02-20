using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 4f;
    [SerializeField] private float lifetime = 8f;
    [SerializeField] private PlayerDeathController playerDeathController;

    private void Start()
    {
        Destroy(gameObject, lifetime);
    }

    private void Update()
    {
        transform.Translate(bulletSpeed * Time.deltaTime * Vector2.left);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            playerDeathController.HandlePlayerDeath();
        }
        Destroy(gameObject);
    }
}
