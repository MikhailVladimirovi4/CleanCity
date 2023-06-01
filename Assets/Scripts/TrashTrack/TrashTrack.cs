using UnityEngine;

[RequireComponent(typeof(MovementTrack))]
[RequireComponent(typeof(SpaceCargo))]
[RequireComponent(typeof(Navigator))]

public class TrashTrack : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _maxFuelTank;
    [SerializeField] private float _fuelConsumption;
    [SerializeField] private int _cargoSize;
    [SerializeField] private int _loadingSpeed;

    private Vector3 _parkingPosition;
    private readonly float _biasPozitionY = 0.5f;
    private MovementTrack _movement;
    private SpaceCargo _spaceCargo;
    private Navigator _navigator;
    private Timer _timer;

    public bool IsFree { get; private set; }

    public int SpeedTime => _timer.SpeedTime;

    private void OnEnable()
    {
        _parkingPosition = new Vector3(transform.position.x, transform.position.y + _biasPozitionY, transform.position.z);
        transform.position = _parkingPosition;
        IsFree = true;
        _movement = GetComponent<MovementTrack>();
        _movement.SetSpeed(_speed);
        _spaceCargo = GetComponent<SpaceCargo>();
        _spaceCargo.SetCargoSize(_cargoSize);
        _spaceCargo.SetLoadingSpeed(_loadingSpeed);
        _navigator = GetComponent<Navigator>();
    }

    public void InitTimer(Timer timer)
    {
        _timer = timer;
    }

    public void Work(AreaState area, Transform startPosition)
    {
        IsFree = false;
        _navigator.CreateRoute(area);
        _movement.SetTarget(startPosition);
    }
}
