using UnityEngine;

[RequireComponent(typeof(Navigator))]
[RequireComponent(typeof(TrashTrack))]

public class MovementTrack : MonoBehaviour
{
    private Transform _target;
    private Navigator _navigator;
    private TrashTrack _track;
    private float _speed;

    private void OnEnable()
    {
        _navigator = GetComponent<Navigator>();
        _track = GetComponent<TrashTrack>();
        _target = null;
    }

    private void Update()
    {
        if (_target != null)
        {
            if (transform.position != _target.position)
            {
                transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * _track.SpeedTime * Time.deltaTime);
            }
            else
            {
                _target = _navigator.NextTarget();
            }
        }
        else
        {
            _track.TagFree();
        }
    }

    public void SetSpeed(float speed) => _speed = speed;
    public void SetTarget(Transform target) => _target = target;
}
