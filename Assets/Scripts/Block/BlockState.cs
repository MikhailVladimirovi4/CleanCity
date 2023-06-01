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
    [SerializeField] private StateDisplay _stateDisplay;

    private int _trashCount;
    private int _personTrashOneTime;
    private bool _addResidents;
    private int _trashMaxIndex;
    private int _startSupportBlock = 50;

    public bool IsIncluded { get; private set; }
    public int PublicSupportBlock { get; private set; }

    public int Residents => _residents;
    public int TrashCount => _trashCount;
    public int TrashMaxIndex => _trashMaxIndex;
    public WaitForSeconds TimerDelay => _timer.Delay;

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
        _personTrashOneTime = _controller.GetTrashRatePerson;
        _addResidents = true;
        IsIncluded = false;
        _stateDisplay.gameObject.SetActive(false);
        PublicSupportBlock = _startSupportBlock;
    }

    public void Includ()
    {
        IsIncluded = true;
        _stateDisplay.gameObject.SetActive(true);
    }

    public void RemoveTrash(int loadingSpeed, out int sendTrashCount,out bool isSendTrash)
    {
        isSendTrash = true;

        if (_trashCount < loadingSpeed * _timer.SpeedTime)
        {
            sendTrashCount = _trashCount;
            isSendTrash = false;
        }
        else
        {
            sendTrashCount = loadingSpeed * _timer.SpeedTime;
        }

        _trashCount -= sendTrashCount;
    }

    private void AddResidents()
    {
        if (_addResidents && _residents < _maxResidents)
        {
            _residents++;
            PublicSupportBlock += 10;

            if (PublicSupportBlock > _controller.PerCent)
                PublicSupportBlock = _controller.PerCent;

        }
        else
        {
            if (!_addResidents && _residents > _minResidents)
                _residents--;

            _addResidents = true;
            PublicSupportBlock -= 10;

            if (PublicSupportBlock < 0)
                PublicSupportBlock = 0;
        }
    }

    private void AddTrash(int timeSpeed)
    {
        if (IsIncluded)
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
}
