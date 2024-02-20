using UnityEngine;

public class ActivationController : MonoBehaviour
{
    [SerializeField] private GameObject checkingObj;
    private MoveController moveController;

    private void Awake()
    {
        moveController = GetComponent<MoveController>();
    }

    private void Update()
    {
        if (!checkingObj.activeSelf)
        {
            moveController.enabled = true;
        }
    }
}
