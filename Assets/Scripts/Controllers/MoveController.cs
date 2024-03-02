using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField] private Vector3 _startPoint;
    [SerializeField] private Vector3 _endPoint;
    [SerializeField] private float _speed = 2.0f;

    private Vector3 _target;

    private void Start()
    {
        _target = _endPoint;
    }

    private void Update()
    {
        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target, step);

        if (Vector3.Distance(transform.position, _target) < 0.001f)
        {
            if (_target == _startPoint)
            {
                _target = _endPoint;
            }
            else
            {
                _target = _startPoint;
            }                        
        }
    }
}