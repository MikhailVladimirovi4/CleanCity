using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Office : MonoBehaviour
{
    [SerializeField] private Text _coin;
    [SerializeField] private Text _reputationValue;
    [SerializeField] private Text _garageLevel;
    [SerializeField] private Text _parkingPlace;
    [SerializeField] private Text _freeParkingPlace;
    [SerializeField] private Text _trashTrack;
    [SerializeField] private Text _freeTrashTrack;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private List<Place> _places;

    private List<TrashTrack> _tracks = new List<TrashTrack>();
    private int _reputation = 0;



    private void OnEnable()
    {
        UpdateValues();
    }

    private void OnDisable()
    {
    }

    public void UpLevel()
    {
        Debug.Log("поднять уровень");
    }

    public void AddTrack()
    {
        Debug.Log("поднять track");
    }

    public void AddPlace()
    {
        Debug.Log("поднять place");
    }

    private void UpdateValues()
    {
        _coin.text = Convert.ToString(_wallet.Coints);
        _parkingPlace.text = Convert.ToString(GetPlaceCount());
        _trashTrack.text = Convert.ToString(GetTrackCount());
        _reputationValue.text = Convert.ToString(_reputation);
    }

    private int GetPlaceCount()
    {
        int count = 0;

        foreach (Place place in _places)
        {
            if (place.gameObject.activeSelf)
                count++;
        }

        return count;
    }

    private int GetTrackCount()
    {
        int count = 0;

        foreach (TrashTrack track in _tracks)
            count++;

        return count;
    }
}
