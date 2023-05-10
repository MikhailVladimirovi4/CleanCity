using System.Collections;
using UnityEngine;

public class BlackState : MonoBehaviour
{
    [SerializeField] private int _residents;
    [SerializeField] private int _trashMaxIndex;
    [SerializeField] private Timer _timer;
    [SerializeField] private GameController _controller;
    [SerializeField] private Smell _smell;

    private float _trashCount;
    private int _addTrash;

    public int GetResidents() => _residents;
    public float GetTrashCount() => _trashCount;
    public int GetTrashMaxIndex() => _trashMaxIndex;

    private void Start()
    {
        _addTrash = _controller.GetTrashRatePerson();
        StartCoroutine(AddTrash());
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
            }
            yield return _timer.GetDelay();
        }
    }
}
