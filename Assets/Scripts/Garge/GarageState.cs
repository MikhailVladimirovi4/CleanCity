using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

[RequireComponent(typeof(TrackPark))]

public class GarageState : MonoBehaviour
{
    [SerializeField] private GarageBox _box;
    [SerializeField] private StoonFloor _floor;
    [SerializeField] private Trees _trees;
    [SerializeField] private Bench _bench;

    public int Level { get; private set; }
    private TrackPark _trackPark;

    private void Start()
    {
        Level = 0;
        _trackPark = GetComponent<TrackPark>();
    }

    public void UpLevel()
    {
        Level++;

        switch (Level)
        {
            case 1:
                _box.gameObject.SetActive(true);
                break;
            case 2:
                _floor.gameObject.SetActive(true);
                break;
            case 3:
                _bench.gameObject.SetActive(true);
                break;
            case 4:
                _trees.gameObject.SetActive(true);
                break;
        }
    }

    public void AddParkingPlace() => _trackPark.AddPlace();
}
