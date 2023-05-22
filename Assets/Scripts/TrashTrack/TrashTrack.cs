using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashTrack : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _cargoSize;
    [SerializeField] private int _loadingSpeed;
    [SerializeField] private float _maxFuelTank;
    [SerializeField] private float _fuelConsumption;
    [SerializeField] private Timer _timer;

    private int _currentTrash;
    private Transform _targetMove;

    public int GetCargoSize() => _cargoSize;
    public int GetCurrentTrash() => _currentTrash;
    public int GetLoadingSpeed() => _loadingSpeed;

    private void Awake()
    {
        this.gameObject.SetActive(false);
    }

    public void AddTrash(int addTrash)
    {
        if (_currentTrash < _cargoSize)
            _currentTrash += addTrash * _timer.GetTimeSpeed();
        else
            _currentTrash = _cargoSize;
    }

    public void RemoveTrash()
    {
        _currentTrash = 0;
    }
}
