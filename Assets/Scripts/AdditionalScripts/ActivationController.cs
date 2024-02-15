using UnityEngine;

public class ActivationController : MonoBehaviour
{
    public GameObject checkingObj;
    private MoveController moveController;

    private void Start()
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
