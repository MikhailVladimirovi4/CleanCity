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

    private MovementTrack _movement;
    private SpaceCargo _spaceCargo;
    private Navigator _navigator;
    private Timer _timer;

    [SerializeField] public bool IsFree { get; private set; }

    public int SpeedTime => _timer.SpeedTime;

    private void OnEnable()
    {
        IsFree = true;
        _movement = GetComponent<MovementTrack>();
        _movement.SetSpeed(_speed);
        _spaceCargo = GetComponent<SpaceCargo>();
        _spaceCargo.SetCargoSize(_cargoSize);
        _spaceCargo.SetLoadingSpeed(_loadingSpeed);
        _navigator = GetComponent<Navigator>();
    }

    public void TagFree() => IsFree = true;

    public void Init(Timer timer, Transform[] removeTrashPoints)
    {
        _timer = timer;
        _navigator.CreateRemoveTrashRoute(removeTrashPoints);
    }

    public void Work(AreaState area, Transform startPosition)
    {
        IsFree = false;
        _navigator.CreateRoute(area);
        _movement.SetTarget(startPosition);
    }
}
