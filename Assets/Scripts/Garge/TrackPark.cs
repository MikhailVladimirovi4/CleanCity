using System.Collections.Generic;
using UnityEngine;

public class TrackPark : MonoBehaviour
{
    [SerializeField] private Transform _parking;

    private List<TrashTrack> _tracks;
    private Place[] _places;

    private void OnEnable()
    {
        _places = new Place[_parking.childCount];
    }

    public int GetMaxPlace => _places.Length;

    public int GetPlace()
    {
        int number = 0;

        foreach (Place place in _places)
        {
            if (place.gameObject.activeSelf)
                number++;
        }

        return number;
    }

    public void AddPlace()
    {
        if ( GetPlace() < _places.Length + 1)
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
}
