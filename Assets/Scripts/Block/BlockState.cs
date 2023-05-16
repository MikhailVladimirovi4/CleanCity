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
    [SerializeField] private Smell _smell;

    private int _trashCount;
    private int _addTrash;
    private bool _addResidents;
    private int _trashMaxIndex;
    private WaitForSeconds _delay;
    private Coroutine _addTrashCoroutine;

    public int GetResidents() => _residents;
    public int GetTrashCount() => _trashCount;
    public int GetTrashMaxIndex() => _trashMaxIndex;
    public WaitForSeconds GetDelay() => _delay;

    private void OnEnable()
    {
        _trashMaxIndex = _maxResidents * _timer.GetTimeDay();
        _timer.WeekIsOver += AddResidents;
    }

    private void OnDisable()
    {
        _timer.WeekIsOver -= AddResidents;
    }

    private void Start()
    {
        _addTrash = _controller.GetTrashRatePerson();
        _addResidents = true;
        _delay = _timer.GetDelay();
        _addTrashCoroutine = StartCoroutine(AddTrash());
    }

    public void AddResidents()
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

    IEnumerator AddTrash()
    {
        while (_timer.IsPlaying)
        {
            if (_trashCount < _trashMaxIndex)
            {
                _trashCount += _residents * _addTrash * _timer.GetTimeSpeed();
            }
            else
            {
                _smell.gameObject.SetActive(true);
                _addResidents = false;
            }

            yield return _delay;
        }
    }
}
