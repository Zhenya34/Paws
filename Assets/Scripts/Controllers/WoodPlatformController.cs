using UnityEngine;

public class WoodPlatformController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private LayerMask _playerLayer;

    private BoxCollider2D _platformCollider;
    private Collider2D _playerCollider;

    private void Awake()
    {
        _platformCollider = GetComponent<BoxCollider2D>();
        _playerCollider = _rb.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (_rb != null)
        {
            float verticalVelocity = _rb.velocity.y;

            if (verticalVelocity > 0)
            {
                Physics2D.IgnoreCollision(_platformCollider, _playerCollider, true);
            }
            else
            {
                Physics2D.IgnoreCollision(_platformCollider, _playerCollider, false);
            }
        }
    }
}