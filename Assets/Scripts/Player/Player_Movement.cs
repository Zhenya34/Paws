using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float speed = 8;
    [SerializeField] private float jumpForce = 5;
    [SerializeField] private float jumpDelay = 0.2f;
    [SerializeField] private float uiHorizontalInput;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private AudioSource _as;
    [SerializeField] private AudioClip jumpSound;

    private bool hasJumpSoundPlayed = false;
    private float _horizontalInput;
    private float jumpTimer = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (jumpTimer > 0)
        {
            jumpTimer -= Time.deltaTime;
            if (Mathf.Abs(_rb.velocity.y) < 0.01f && !hasJumpSoundPlayed)
            {
                _as.PlayOneShot(jumpSound);
                hasJumpSoundPlayed = true;
                _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                StartCoroutine(ResetJumpSoundPlayed());
            }
            else if (hasJumpSoundPlayed)
            {
                jumpTimer = 0f;
            }
        }
    }

    public void Jump()
    {
        if (Mathf.Abs(_rb.velocity.y) < 0.01 && !hasJumpSoundPlayed)
        {
            _as.PlayOneShot(jumpSound);
            hasJumpSoundPlayed = true;
            _rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            StartCoroutine(ResetJumpSoundPlayed());
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
    private System.Collections.IEnumerator ResetJumpSoundPlayed()
    {
        yield return new WaitForSeconds(jumpDelay);
        hasJumpSoundPlayed = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hasJumpSoundPlayed = false;
    }
}
