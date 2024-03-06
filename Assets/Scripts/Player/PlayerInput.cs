using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Player_Movement _playerMovement;
    [SerializeField] private PlayerAnimController _playerAnimController;

    public void OnJumpButtonClicked()
    {
        if (_playerMovement != null)
        {
            _playerMovement.Jump();
            _playerAnimController.JumpAnimation();
        }
    }

    public void OnLeftButtonClicked()
    {
        _playerAnimController.isRunning = true;
        _playerMovement.MoveLeft();        
    }

    public void OnRightButtonClicked()
    {
        _playerAnimController.isRunning = true;
        _playerMovement.MoveRight();        
    }

    public void OnButtonUp()
    {
        _playerAnimController.isRunning = false;
        _playerMovement.StopMoving();
    }
}