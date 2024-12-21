using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _smoothSpeed;

    private readonly float _minY = 0;
    private readonly float _maxY = 100;

    private void LateUpdate()
    {
        //It is second branch
        if (_target != null)
        {
            float clampedY = Mathf.Clamp(_target.position.y, _minY, _maxY);

            Vector3 desiredPosition = new(_target.position.x, clampedY, -100.3f);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
        }
    } 
}
