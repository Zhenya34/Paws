using TMPro;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float _bulletSpeed = 4f;
    [SerializeField] private float _lifetime = 8f;
    [SerializeField] private PlayerDeathController _playerDeathController;

    private void Start()
    {
        Destroy(gameObject, _lifetime);
    }

    private void Update()
    {
        transform.Translate(_bulletSpeed * Time.deltaTime * Vector2.left);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            _playerDeathController.HandlePlayerDeath();
        }
        Destroy(gameObject);
    }
}
