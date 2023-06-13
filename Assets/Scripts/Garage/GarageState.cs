using System.Collections;
using UnityEngine;

[RequireComponent(typeof(TrackPark))]

public class GarageState : MonoBehaviour
{
    [SerializeField] private GarageBox _box;
    [SerializeField] private StoonFloor _floor;
    [SerializeField] private Trees _trees;
    [SerializeField] private Bench _bench;
    [SerializeField] private int _maxLevelGarage;
    [SerializeField] private AudioSource _upLevelAudio;
    [SerializeField] private Smoke _smoke;
    [SerializeField] private Timer _timer;

    private TrackPark _trackPark;
    private Coroutine _building;
    public int Level { get; private set; }
    public int MaxLevelGarage => _maxLevelGarage;

    private void Start()
    {
        Level = 1;
        _trackPark = GetComponent<TrackPark>();
    }

    public void UpLevel()
    {
        Level++;
        _upLevelAudio.Play();

        if (_building != null)
            StopCoroutine(_building);

        _building = StartCoroutine(Building());


        switch (Level)
        {
            case 2:
                _box.gameObject.SetActive(true);
                break;
            case 3:
                _floor.gameObject.SetActive(true);
                break;
            case 4:
                _bench.gameObject.SetActive(true);
                break;
            case 5:
                _trees.gameObject.SetActive(true);
                break;
        }
    }

    public void AddParkingPlace() => _trackPark.AddPlace();

    IEnumerator Building()
    {
        int duration = 2;

        _smoke.gameObject.SetActive(true);

        while (duration >0)
        {
            duration--;

            yield return _timer.Delay;
        }

        _smoke.gameObject.SetActive(false);
    }
}
