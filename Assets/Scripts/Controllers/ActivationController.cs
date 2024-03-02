using UnityEngine;

public class ActivationController : MonoBehaviour
{
    [SerializeField] private GameObject _checkingObj;
    private MoveController _moveController;

    private void Awake()
    {
        _moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        if (!_checkingObj.activeSelf)
        {
            _moveController.enabled = true;
        }
    }
}
