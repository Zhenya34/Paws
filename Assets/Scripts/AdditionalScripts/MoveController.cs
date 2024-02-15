using UnityEngine;

public class MoveController : MonoBehaviour
{
    public Vector3 startPoint;
    public Vector3 endPoint;
    public float speed = 2.0f;

    private Vector3 _target;

    void Start()
    {
        _target = endPoint;
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target, step);

        if (Vector3.Distance(transform.position, _target) < 0.001f)
        {
            if (_target == startPoint)
            {
                _target = endPoint;
            }
            else
            {
                _target = startPoint;
            }         
                            
        }
    }
}