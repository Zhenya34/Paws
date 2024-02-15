using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public float speed = 8;
    public float jumpForce = 5;
    public float jumpDelay = 0.2f;
    public float uiHorizontalInput;
    private float _horizontalInput;
    private float jumpTimer = 0;


    private Rigidbody2D _rb;
    private SpriteRenderer _sr;


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
            if (Mathf.Abs(_rb.velocity.y) < 0.01f)
            {
                _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    public void Jump()
    {
        if (Mathf.Abs(_rb.velocity.y) < 0.01f)
        {
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
        jumpTimer = jumpDelay;
    }

    public void MoveRight()
    {
        uiHorizontalInput = 1;
    }

    public void MoveLeft()
    {
        uiHorizontalInput = -1;
    }

    public void StopMoving()
    {
        uiHorizontalInput = 0;
    }

    private void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        float combinedInput = Mathf.Abs(_horizontalInput) > Mathf.Abs(uiHorizontalInput) ? _horizontalInput : uiHorizontalInput;

        transform.position += speed * Time.deltaTime * new Vector3(combinedInput, 0, 0);

        if (combinedInput != 0)
        {
            _sr.flipX = combinedInput > 0;
        }            
    }
}
