using System.Collections.Generic;
using UnityEngine;

public class TrackPark : MonoBehaviour
{
    [SerializeField] private Transform _parking;
    [SerializeField] private List<TrashTrack> _tracks;
    [SerializeField] private List<Place> _places;
    [SerializeField] private TrashTrack _track;

    private void OnEnable()
    {
        CreateTrack();
    }

    public void AddPlace()
    {
        if (GetPlaceCount() < _places.Count)
        {
            foreach (Place place in _places)
            {
                if (!place.gameObject.activeSelf)
                {
                    place.gameObject.SetActive(true);
                    return;
                }
            }
        }
    }

    public int GetPlaceCount()
    {
        int count = 0;

        foreach (Place place in _places)
        {
            if (place.gameObject.activeSelf)
                count++;
        }

        return count;
    }

    public int GetTrackCount()
    {
        int count = 0;

        foreach (TrashTrack track in _tracks)
        {
            if (track.gameObject.activeSelf)
                count++;
        }

        return count;
    }

    private void CreateTrack()
    {
        for (int i = 0; i < _places.Count; i++)
        {
            Instantiate(_track, _places[i].transform.position, Quaternion.identity);
            _tracks.Add(_track);
            _track.gameObject.SetActive(false);
        }
    }
}
