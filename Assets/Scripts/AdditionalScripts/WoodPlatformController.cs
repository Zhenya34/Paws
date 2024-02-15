using UnityEngine;

public class WoodPlatformController : MonoBehaviour
{
    private BoxCollider2D _platformCollider;
    private Collider2D _playerCollider;
    public Rigidbody2D rb;
    public LayerMask playerLayer;

    private void Start()
    {
        _platformCollider = GetComponent<BoxCollider2D>();
        _playerCollider = rb.GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (rb != null)
        {
            float verticalVelocity = rb.velocity.y;

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