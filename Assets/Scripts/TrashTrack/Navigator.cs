using UnityEngine;

public class Navigator : MonoBehaviour
{
    private Transform[] _removeTrashPoints;
    private Transform[] _collectTrashPoints;
    private Transform _startPosition;
    private int routeLeg;

    public Transform NextTarget()
    {
        Transform nextTarget;

        if (routeLeg < _collectTrashPoints.Length)
        {
            nextTarget = _collectTrashPoints[routeLeg];
        }
        else
        {
            if (routeLeg < _collectTrashPoints.Length + _removeTrashPoints.Length)
            {
                nextTarget = _removeTrashPoints[routeLeg - _collectTrashPoints.Length];
            }
            else
            {
                if (gameObject.transform != _startPosition)
                    nextTarget = _startPosition;
                else
                    nextTarget = null;
            }
        }

        routeLeg++;

        return nextTarget;
    }

    public void CreateRoute(AreaState area)
    {
        _startPosition = gameObject.transform;
        routeLeg = 0;

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
