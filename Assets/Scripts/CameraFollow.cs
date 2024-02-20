using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float smoothSpeed;

    private readonly float _minY = 0;
    private readonly float _maxY = 100;

    private void LateUpdate()
    {
        if (target != null)
        {
            float clampedY = Mathf.Clamp(target.position.y, _minY, _maxY);

            Vector3 desiredPosition = new(target.position.x, clampedY, -100.3f);
            transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        }
    } 
}
