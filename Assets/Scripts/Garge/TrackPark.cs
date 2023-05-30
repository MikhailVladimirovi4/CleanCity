using System;
using System.Collections.Generic;
using UnityEngine;

public class TrackPark : MonoBehaviour
{
    [SerializeField] private Transform _parking;
    [SerializeField] private List<TrashTrack> _tracks;
    [SerializeField] private List<Place> _places;
    [SerializeField] private TrashTrack _track;

    public int CurrentCountPlace { get; private set; }
    public int CurrentCountTrack { get; private set; }
    public int MaxCountPlace { get; private set; }


    private void Start()
    {
        CurrentCountPlace = 0;
        CurrentCountTrack = 0;
        MaxCountPlace = _places.Count;
    }
    public void AddTrashTrack()
    {
        foreach (Place place in _places)
        {
            if (place.gameObject.activeSelf && !place.IsBusy)
            {
                TrashTrack track = Instantiate(_track, place.transform.position, Quaternion.identity);
                _tracks.Add(track);
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

    public void SendTrashTrack(AreaState target)
    { 

    }

    public TrashTrack IsFreeTrack()
    {
        foreach( TrashTrack track in _tracks)
        {
            if(track.IsFree)
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
}
