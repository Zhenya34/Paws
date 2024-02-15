using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    [SerializeField] private float IdleTimer = 10;
    [SerializeField] private float raycastDistance = 1.0f;
    public bool isRunning = false;

    private void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("IdleWait"))
        {
            IdleTimer -= Time.deltaTime;

            if (IdleTimer <= 0)
            {
                animator.SetBool("Idle", true);
            }
            else
            {
                animator.SetBool("Idle", false);
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
            animator.SetTrigger("Jump");
            IdleTimer = 10;
        }
    }

    public void IsRunningTrue()
    {
        IdleTimer = 10;
        animator.SetBool("IsRunning", true);
    }

    public void IsRunningFalse()
    {
        animator.SetBool("IsRunning", false);
    }

    bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance);
        return hit.collider != null;
    }
}
