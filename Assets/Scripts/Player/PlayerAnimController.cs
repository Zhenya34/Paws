using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private float _idleTimer = 10;
    [SerializeField] private float _raycastDistance = 1.0f;
    public bool isRunning = false;

    private enum AnimationState
    {
        IdleWait,
        IsRunning,
        Idle,
        Jump,
    }

    private void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName(AnimationState.IdleWait.ToString()))
        {
            _idleTimer -= Time.deltaTime;

            if (_idleTimer <= 0)
            {
                _animator.SetBool(AnimationState.Idle.ToString(), true);
            }
            else
            {
                _animator.SetBool(AnimationState.Idle.ToString(), false);
            }                
        }

        float moveInput = Input.GetAxis("Horizontal");

        if (isRunning || moveInput != 0)
        {
            IsRunningTrue();
        }
        else
        {
            IsRunningFalse();
        }    

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpAnimation();
        }            
    }

    public void JumpAnimation()
    {
        if (IsGrounded())
        {
            _animator.SetTrigger(AnimationState.Jump.ToString());
            _idleTimer = 10;
        }
    }

    public void IsRunningTrue()
    {
        _idleTimer = 10;
        _animator.SetBool(AnimationState.IsRunning.ToString(), true);
    }

    public void IsRunningFalse()
    {
        _animator.SetBool(AnimationState.IsRunning.ToString(), false);
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance);
        return hit.collider != null;
    }
}
