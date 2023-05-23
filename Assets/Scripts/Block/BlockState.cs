using System.Collections;
using System.Diagnostics.Contracts;
using UnityEngine;

public class BlockState : MonoBehaviour
{
    [SerializeField] private int _residents;
    [SerializeField] private int _maxResidents;
    [SerializeField] private int _minResidents;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameController _controller;
    [SerializeField] private Smoke _smoke;

    private int _trashCount;
    private int _personTrashOneTime;
    private bool _addResidents;
    private int _trashMaxIndex;

    public int GetResidents() => _residents;
    public int GetTrashCount() => _trashCount;
    public int GetTrashMaxIndex() => _trashMaxIndex;

    private void OnEnable()
    {
        _trashMaxIndex = _maxResidents * _timer.GetTimeDay();
        _timer.WeekIsOver += AddResidents;
        _timer.TimeChanged += AddTrash;
    }

    private void OnDisable()
    {
        _timer.WeekIsOver -= AddResidents;
        _timer.TimeChanged -= AddTrash;
    }

    private void Start()
    {
        _personTrashOneTime = _controller.GetTrashRatePerson();
        _addResidents = true;
    }

    private void AddResidents()
    {
        if (_addResidents && _residents < _maxResidents)
        {
            _residents++;
        }
        else
        {
            if (!_addResidents && _residents > _minResidents)
                _residents--;

            _addResidents = true;
        }
    }

    public void RemoveTrash(int index)
    {
        if (_trashCount > 0 && _trashCount > index)
            _trashCount -= index * _timer.GetTimeSpeed();
        else
            _trashCount = 0;
    }

    private void AddTrash(int timeSpeed)
    {
        if (_trashCount < _trashMaxIndex)
        {
            _trashCount += _residents * _personTrashOneTime * timeSpeed;
        }
        else
        {
            _smoke.gameObject.SetActive(true);
            _addResidents = false;
        }
    }
}
