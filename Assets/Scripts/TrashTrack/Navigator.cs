using UnityEngine;

[RequireComponent(typeof(SpaceCargo))]

public class Navigator : MonoBehaviour
{
    private Transform[] _removeTrashPoints;
    private Transform[] _collectTrashPoints;
    private Transform _parkingPosition;
    private SpaceCargo _spaceCargo;
    private int _routeStep = 0;
    private TrashTrack _track;

    private void Start()
    {
        _track = GetComponent<TrashTrack>();
        _spaceCargo = GetComponent<SpaceCargo>();
    }

    public void SetParkingPosition(Transform parkingPosition) => _parkingPosition = parkingPosition;

    public Transform GetTarget()
    {
        Transform nextTarget;

        if (_routeStep < _collectTrashPoints.Length)
        {
                nextTarget = _collectTrashPoints[_routeStep];

            if (_spaceCargo.IsFull)
                _routeStep = _collectTrashPoints.Length - 1;
        }

        else
        {
            if (_routeStep < _collectTrashPoints.Length + _removeTrashPoints.Length)
            {
                nextTarget = _removeTrashPoints[_routeStep - _collectTrashPoints.Length];
            }

            else
            {
                if (gameObject.transform.position != _parkingPosition.position)
                {
                    nextTarget = _parkingPosition;
                }

                else
                {
                    nextTarget = null;
                    _routeStep = 0;

                    if (!_track.IsFree)
                        _track.TagFree();
                }
            }
        }
        _routeStep++;

        return nextTarget;
    }

    public void CreateRoute(AreaState area)
    {
        _routeStep = 0;

        _collectTrashPoints = new Transform[area.RouteMapPoints];

        for (int i = 0; i < _collectTrashPoints.Length; i++)
            _collectTrashPoints[i] = area.GetRouteCollectPoint(i);
    }

    public void CreateRemoveTrashRoute(Transform[] removeTrashPoints)
    {
        _removeTrashPoints = new Transform[removeTrashPoints.Length];

        for (int i = 0; i < removeTrashPoints.Length; i++)
            _removeTrashPoints[i] = removeTrashPoints[i];
    }
}
