using UnityEngine;

[RequireComponent(typeof(MovementTrack))]
[RequireComponent(typeof(Navigator))]
[RequireComponent(typeof(SpaceCargo))]

public class TrashTrack : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _loadingSpeed;
    [SerializeField] private float _maxFuelTank;
    [SerializeField] private float _fuelConsumption;

    private AreaState _targetArea;
    private Vector3 _parkingPosition;
    private readonly float _biasPozitionY = 0.5f;
    private MovementTrack _movement;
    private Navigator _novigator;
    private SpaceCargo _spaceCargo;

    public bool IsFree { get; private set; }

    private void OnEnable()
    {
        _parkingPosition = new Vector3(transform.position.x, transform.position.y + _biasPozitionY, transform.position.z);
        transform.position = _parkingPosition;
        IsFree = true;
        _movement = GetComponent<MovementTrack>();
        _novigator = GetComponent<Navigator>();
        _spaceCargo = GetComponent<SpaceCargo>();
        _movement.SetSpeed(_speed);
    }

    public void Work(AreaState area, Transform startPosition)
    {
        IsFree = false;
        _targetArea = area;
        _movement.SetTarget(startPosition);
    }
}
