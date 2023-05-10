using System.Collections;
using UnityEngine;

public class BlackState : MonoBehaviour
{
    [SerializeField] private int _residents;
    [SerializeField] private int _maxResidents;
    [SerializeField] private int _minResidents;
    [SerializeField] private int _trashMaxIndex;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameController _controller;
    [SerializeField] private Smell _smell;

    private float _trashCount;
    private int _addTrash;
    private bool _addResidents;

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
            _addResidents = true;

            if (_residents > _minResidents)
                _residents--;

        }
    }

    IEnumerator AddTrash()
    {
        while (_timer.IsPlaying)
        {
            if (_trashCount < _trashMaxIndex)
            {
                _trashCount += _residents * _addTrash;
                _smell.gameObject.SetActive(false);
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
