using System.Collections;
using UnityEngine;

public class BlackState : MonoBehaviour
{
    [SerializeField] private int _residents;
    [SerializeField] private int _maxResidents;
    [SerializeField] private int _minResidents;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameController _controller;
    [SerializeField] private Smell _smell;

    private float _trashCount;
    private int _addTrash;
    private bool _addResidents;
    private int _trashMaxIndex;

    public int GetResidents() => _residents;
    public float GetTrashCount() => _trashCount;
    public int GetTrashMaxIndex() => _trashMaxIndex;

    private void OnEnable()
    {
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
        _trashMaxIndex = _maxResidents * _timer.GetTimeDay();
        StartCoroutine(AddTrash());
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

            yield return _timer.GetDelay();
        }
    }
}
