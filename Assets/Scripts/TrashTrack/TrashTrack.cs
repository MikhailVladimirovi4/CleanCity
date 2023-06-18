using UnityEngine;

[RequireComponent(typeof(MovementTrack))]
[RequireComponent(typeof(Navigator))]

public class TrashTrack : MonoBehaviour
{
    private MovementTrack _movement;
    private Navigator _navigator;
    private Timer _timer;
    private bool _isFree;
    private AreaState _area;

    public bool IsFree => _isFree;
    public int SpeedTime => _timer.SpeedTime;
    public bool IsAllowMove { get; private set; }

    private void OnEnable()
    {
        _isFree = true;
        IsAllowMove = true;
        _movement = GetComponent<MovementTrack>();
        _navigator = GetComponent<Navigator>();
    }

    public void AllowMove(bool isAllowMove) => IsAllowMove = isAllowMove;

    public void MarkEndCollection()
    {
        _area.OffCollectionProgress();
    }

    public void TagFree()
    {
        _area = null;
        _isFree = true;
    }

    public void Init(Timer timer, Transform[] removeTrashPoints, Transform parkingPosition)
    {
        _timer = timer;
        _navigator.CreateRemoveTrashRoute(removeTrashPoints);
        _navigator.SetParkingPosition(parkingPosition);
    }

    public void Work(AreaState area, Transform startPosition)
    {
        _area = area;
        _isFree = false;
        _navigator.CreateRoute(_area);
        _movement.SetTarget(startPosition);
    }
}
