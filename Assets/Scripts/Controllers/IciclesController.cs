using System.Collections;
using UnityEngine;

public class IciclesController : MonoBehaviour
{
    [SerializeField] private float _waitingTime = 1f;
    [SerializeField] private float _downtime = 0.5f;
    [SerializeField] private float _raycastDistance;

    private Rigidbody2D _rb;
    private bool _isFalling = false;
    private bool _hasStartedFallingCoroutine = false;
    private bool _hasStartedWaitAndDestroyCoroutine = false;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, _raycastDistance);

        if (hit.collider != null && hit.collider.CompareTag("Player") && !_hasStartedFallingCoroutine)
        {
            _hasStartedFallingCoroutine = true;
            StartCoroutine(StartFallingCoroutine());
        }

        if (_isFalling && !_rb.simulated && !_hasStartedWaitAndDestroyCoroutine)
        {
            _hasStartedWaitAndDestroyCoroutine = true;
            _rb.simulated = true;
            StartCoroutine(WaitAndDestroyCoroutine());
        }
    }

    IEnumerator StartFallingCoroutine()
    {
        yield return new WaitForSeconds(_waitingTime);
        _isFalling = true;
    }

    IEnumerator WaitAndDestroyCoroutine()
    {
        yield return new WaitForSeconds(_downtime);
        Destroy(gameObject);
    }
}