using UnityEngine;

public class BlockState : MonoBehaviour
{
    [SerializeField] private int _maxResidents;
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
    }

    private void OnDisable()
    {
        _timer.DayIsOver -= AddResidents;
        _timer.TimeChanged -= AddTrash;
    }

    private void Start()
    {
        _trashMaxIndex = _maxResidents * _timer.GetTimeDay();
        _personTrashOneTime = _controller.GetTrashRatePerson;
        _addResidents = true;
        IsIncluded = false;
        _stateDisplay.gameObject.SetActive(false);
        PublicSupportBlock = _controller.StartSupportBlock;
        _residents = _maxResidents * _controller.IndexStartPeopleBlock / _controller.PerCent;
    }

    public void Includ()
    {
        IsIncluded = true;
        _stateDisplay.gameObject.SetActive(true);
        _timer.DayIsOver += AddResidents;
        _timer.TimeChanged += AddTrash;
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
        if (_addResidents)
        {
            if (_residents < _maxResidents)
                _residents++;

            PublicSupportBlock += _controller.StepAddSupportPeople;

            if (PublicSupportBlock > _controller.PerCent)
                PublicSupportBlock = _controller.PerCent;
        }
        else
        {
            if (_residents > _controller.IndexMinPeopleBlock)
                _residents--;

            PublicSupportBlock -= _controller.StepRemoveSupportPeople;

            if (PublicSupportBlock < 0)
                PublicSupportBlock = 0;

            _addResidents = true;
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
