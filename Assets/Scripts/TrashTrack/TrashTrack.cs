using UnityEngine;

[RequireComponent(typeof(MovementTrack))]
[RequireComponent(typeof(Navigator))]

public class TrashTrack : MonoBehaviour
{
    private MovementTrack _movement;
    private Navigator _navigator;
    private Timer _timer;
    private bool _isFree;
    private AreaState _area = new AreaState();

    public bool IsFree => _isFree;
    public int SpeedTime => _timer.SpeedTime;

    private void OnEnable()
    {
        _isFree = true;
        _movement = GetComponent<MovementTrack>();
        _navigator = GetComponent<Navigator>();
    }

    public void TagFree()
    {
        _area.OffCollectionProgress();
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
        _area.OnCollectionProgress();
        _navigator.CreateRoute(_area);
        _movement.SetTarget(startPosition);
    }
}
