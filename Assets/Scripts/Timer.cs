using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _secondsDelay;

    private int _minutes;
    private int _hours;
    private int _days;
    private WaitForSeconds _delay;
    private bool _isPlaying;

    public int GetMinutes() => _minutes;
    public int GetHours() => _hours;
    public int GetDays() => _days;

    private void Start()
    {
        _delay = new WaitForSeconds(_secondsDelay);
        _isPlaying = true;
        StartCoroutine(TimeFlow());
    }

    private void FixedUpdate()
    {
        if (_minutes >= 60)
        {
            _minutes = 0;
            _hours++;

            if (_hours >= 24)
            {
                _hours = 0;
                _days++;
            }
        }
    }

    IEnumerator TimeFlow()
    {
        while (_isPlaying) 
        {
            _minutes++;
            yield return _delay;
        }
    }
}
