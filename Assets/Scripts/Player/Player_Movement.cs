using UnityEngine;
using System.Collections;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 8;
    [SerializeField] private float _jumpForce = 5;
    [SerializeField] private float _jumpDelay = 0.2f;
    [SerializeField] private float _airJumpWindowDuration = 0.05f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private SpriteRenderer _sr;
    [SerializeField] private AudioSource _runningAudioSource;
    [SerializeField] private AudioSource _jumpingAudioSource;
    [SerializeField] private AudioClip _jumpSound;
    [SerializeField] private AudioClip _runningSound;

    private float _uiHorizontalInput;
    private float _horizontalInput;
    private bool _hasJumpSoundPlayed = false;
    private bool _alreadyJumped = false;
    private bool _isRunning = false;
    private float _jumpTimer = 0;
    private float _airJumpWindowTimer = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (_jumpTimer > 0)
        {
            _jumpTimer -= Time.deltaTime;
            if (Mathf.Abs(_rb.velocity.y) < 0.01f && !_hasJumpSoundPlayed)
            {
                if (_jumpingAudioSource.enabled != false)
                {
                    _jumpingAudioSource.PlayOneShot(_jumpSound);
                }
                _hasJumpSoundPlayed = true;
                _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
                _alreadyJumped = true;
                GameManager._countOfJumps++;
                GameManager.SaveGameData();
                StartCoroutine(ResetJumpSoundPlayed());
            }
            else if (_hasJumpSoundPlayed)
            {
                _jumpTimer = 0f;
            }
        }
    }

    public void Jump()
    {
        if (Mathf.Abs(_rb.velocity.y) < 0.01 && !_hasJumpSoundPlayed)
        {
            if (_jumpingAudioSource.enabled != false)
            {
                _jumpingAudioSource.PlayOneShot(_jumpSound);
            }
            _hasJumpSoundPlayed = true;
            _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            _alreadyJumped = true;
            GameManager._countOfJumps++;
            GameManager.SaveGameData();
            StartCoroutine(ResetJumpSoundPlayed());
        }
        _jumpTimer = _jumpDelay;
        AirJumpAfterFall();
    }

    private void AirJumpAfterFall()
    {
        if (_airJumpWindowTimer > 0)
        {
            _airJumpWindowTimer -= Time.deltaTime;
            if (!_hasJumpSoundPlayed && !_alreadyJumped)
            {
                if (_jumpingAudioSource.enabled != false)
                {
                    _jumpingAudioSource.PlayOneShot(_jumpSound);
                }
                _hasJumpSoundPlayed = true;
                _rb.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
                _alreadyJumped = true;
                GameManager._countOfJumps++;
                GameManager.SaveGameData();
                StartCoroutine(ResetJumpSoundPlayed());
            }
            else if (_hasJumpSoundPlayed)
            {
                _airJumpWindowTimer = 0f;
            }
        }
    }

    public void MoveRight()
    {
        _uiHorizontalInput = 1;
    }

    public void MoveLeft()
    {
        _uiHorizontalInput = -1;
    }

    public void StopMoving()
    {
        _uiHorizontalInput = 0;
    }

    private void FixedUpdate()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        float combinedInput = Mathf.Abs(_horizontalInput) > Mathf.Abs(_uiHorizontalInput) ? _horizontalInput : _uiHorizontalInput;

        transform.position += _speed * Time.deltaTime * new Vector3(combinedInput, 0, 0);

        if (combinedInput != 0 && !(_rb.velocity.y > 0.01f))
        {
            _sr.flipX = combinedInput > 0;
            if (!_isRunning)
            {
                _isRunning = true;
                if(_runningAudioSource.enabled != false)
                {
                    _runningAudioSource.PlayOneShot(_runningSound);
                    _runningAudioSource.Play();
                }
            }
        }   
        else if(combinedInput == 0 || _rb.velocity.y > 0.01f)
        {
            _isRunning = false;
            if (_runningAudioSource.enabled != false)
            {
                _runningAudioSource.Stop();
            }  
        }
    }

    private IEnumerator ResetJumpSoundPlayed()
    {
        yield return new WaitForSeconds(_jumpDelay);
        _hasJumpSoundPlayed = false;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _hasJumpSoundPlayed = false;
        _alreadyJumped = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _airJumpWindowTimer = _airJumpWindowDuration;
    }
}
