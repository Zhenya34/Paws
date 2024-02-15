using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Player_Movement playerMovement;
    public PlayerAnimController playerAnimController;

    public void OnJumpButtonClicked()
    {
        playerMovement.Jump();
        playerAnimController.JumpAnimation();
    }

    public void OnLeftButtonClicked()
    {
        playerAnimController.isRunning = true;
        playerMovement.MoveLeft();        
    }

    public void OnRightButtonClicked()
    {
        playerAnimController.isRunning = true;
        playerMovement.MoveRight();        
    }

    public void OnButtonUp()
    {
        playerAnimController.isRunning = false;
        playerMovement.StopMoving();
    }
}