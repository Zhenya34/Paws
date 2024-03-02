using UnityEngine;

public class BoxController : MonoBehaviour
{
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(_rb.velocity.y) > 0.01f)
        {
            _rb.velocity = new(0f, _rb.velocity.y);
        }
    }
}
