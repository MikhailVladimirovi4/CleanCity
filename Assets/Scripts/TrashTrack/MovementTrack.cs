using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Navigator))]
[RequireComponent(typeof(TrashTrack))]
[RequireComponent(typeof(SpaceCargo))]

public class MovementTrack : MonoBehaviour
{
    [SerializeField] private float _speed;

   [SerializeField] private Transform _target;
    private Navigator _navigator;
    private TrashTrack _track;
    private SpaceCargo _spaceCargo;

    private void OnEnable()
    {
        _navigator = GetComponent<Navigator>();
        _track = GetComponent<TrashTrack>();
        _spaceCargo = GetComponent<SpaceCargo>();
        _target = null;
    }

    private void Update()
    {
        if (_target != null)
        {
            if (!_spaceCargo.IsLoadingtrash)
            {
                transform.rotation = Quaternion.LookRotation(_target.position - transform.position, Vector3.up);

                if (transform.position != _target.position)
                {
                    transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * _track.SpeedTime * Time.deltaTime);
                }
                else
                {
                    _target = _navigator.GetTarget();
                }
            }
        }
    }

    public void SetTarget(Transform target) => _target = target;
}
