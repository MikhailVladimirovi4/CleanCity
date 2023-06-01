using UnityEngine;

[RequireComponent(typeof(Navigator))]

public class MovementTrack : MonoBehaviour
{
    private Transform _target;
    private Navigator _navigator;
    private float _speed;

    private void Start()
    {
        _target = null;
    }

    private void Update()
    {
        if (_target != null)
        {
            if (transform.position.x != _target.position.x && transform.position.z != _target.position.z)
                ChangePosition();
            else
                _target = _navigator.GetTarget(_target.name);
        }
    }

    public void SetSpeed(float speed) => _speed = speed;
    public void SetTarget(Transform target) => _target = target;

    private void ChangePosition()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed); 
    }
}
