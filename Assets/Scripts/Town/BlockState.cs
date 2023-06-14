using System.Collections;
using System.Diagnostics.Contracts;
using UnityEngine;

public class BlockState : MonoBehaviour
{
    [SerializeField] private int _maxResidents;
    [SerializeField] private int _minResidents;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameController _controller;
    [SerializeField] private Smoke _smoke;
    [SerializeField] private StateDisplay _stateDisplay;
    [SerializeField] private TrashLoadingBlock _trashLoadingBlock;

    private int _residents;
    private int _trashCount;
    private int _personTrashOneTime;
    private bool _addResidents;
    private int _trashMaxIndex;
    private readonly int _startSupportBlock = 50;
    private readonly int _stepAddSupportPeople = 2;
    private readonly int _stepRemoveSupportPeople = 10;

    public bool IsIncluded { get; private set; }
    public int PublicSupportBlock { get; private set; }

    public int Residents => _residents;
    public int TrashCount => _trashCount;
    public int TrashMaxIndex => _trashMaxIndex;
    public Transform TransformLoadingBlock => _trashLoadingBlock.transform;
    public WaitForSeconds TimeDelay => _timer.Delay;

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
        _trashMaxIndex = _maxResidents * _timer.GetTimeDay();
        _personTrashOneTime = _controller.GetTrashRatePerson;
        _addResidents = true;
        IsIncluded = false;
        _stateDisplay.gameObject.SetActive(false);
        PublicSupportBlock = _startSupportBlock;
        _residents = _maxResidents * _controller.IndexStartPeopleBlock/ _controller.PerCent;
    }

    public void Includ()
    {
        IsIncluded = true;
        _stateDisplay.gameObject.SetActive(true);
    }

    public void RemoveTrash(int loadingSpeed, out int sendTrashCount, out bool isSendTrash)
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
            PublicSupportBlock += _stepAddSupportPeople;

            if (PublicSupportBlock > _controller.PerCent)
                PublicSupportBlock = _controller.PerCent;

        }
        else
        {
            if (!_addResidents && _residents > _minResidents)
                _residents--;

            _addResidents = true;
            PublicSupportBlock -= _stepRemoveSupportPeople;

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
                _smoke.gameObject.SetActive(false);
            }
            else
            {
                _smoke.gameObject.SetActive(true);
                _addResidents = false;
            }
        }
    }
}
