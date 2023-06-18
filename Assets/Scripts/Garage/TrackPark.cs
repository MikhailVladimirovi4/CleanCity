using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEditor;
using UnityEngine;

public class TrackPark : MonoBehaviour
{
    [SerializeField] private Transform _parking;
    [SerializeField] private List<TrashTrack> _tracks;
    [SerializeField] private List<Place> _places;
    [SerializeField] private TrashTrack _track;
    [SerializeField] private Transform _startWorkPosition;
    [SerializeField] private Transform[] _removeTrashPoints;
    [SerializeField] private Timer _timer;

    public int CurrentCountPlace { get; private set; }
    public int CurrentCountTrack { get; private set; }
    public int MaxCountPlace { get; private set; }
    public bool IsFreeTrack { get; private set; }

    private void Start()
    {
        ResetState();
        MaxCountPlace = _places.Count;
    }

    private void FixedUpdate()
    {
        IsFreeTrack = (GetFreeTrack() != null);
    }

    public void AllowTrackMove() => TrackMove(true);
    public void BanTrackMove() => TrackMove(false);

    public void ResetState()
    {
        CurrentCountPlace = 0;
        CurrentCountTrack = 0;

        foreach (Place place in _places)
        {
            place.Clear();
            place.gameObject.SetActive(false);
        }

        foreach (TrashTrack track in _tracks)
            Destroy(track.gameObject);

        _tracks.Clear();
    }

    public void AddTrashTrack()
    {
        foreach (Place place in _places)
        {
            if (place.gameObject.activeSelf && !place.IsBusy)
            {
                TrashTrack track = Instantiate(_track, place.transform.position, Quaternion.identity);
                _tracks.Add(track);
                track.Init(_timer, _removeTrashPoints, place.transform);
                CurrentCountTrack++;
                place.Take();
                return;
            }
        }
    }

    public void AddPlace()
    {
        foreach (Place place in _places)
        {
            if (!place.gameObject.activeSelf)
            {
                place.gameObject.SetActive(true);
                CurrentCountPlace++;
                return;
            }
        }
    }

    public void SendTrashTrack(AreaState area)
    {
        GetFreeTrack().Work(area, _startWorkPosition);
    }

    public TrashTrack GetFreeTrack()
    {
        foreach (TrashTrack track in _tracks)
        {
            if (track.IsFree)
            {
                return track;
            }
        }
        return null;
    }

    public int CountFreeTrack()
    {
        int freeTrack = 0;

        foreach (TrashTrack track in _tracks)
        {
            if (track.IsFree)
            {
                freeTrack++;
            }
        }
        return freeTrack;
    }

    private void TrackMove(bool isAllowMove)
    {
        foreach (TrashTrack track in _tracks)
            track.AllowMove(isAllowMove);
    }
}
