using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _secondsDelay;
    [SerializeField] private int _timeSpeed;

    private int _minutes;
    private int _hours;
    private int _days;
    private WaitForSeconds _delay;

    public bool IsPlaying { get; private set; }

    public int GetMinutes() => _minutes;
    public int GetHours() => _hours;
    public int GetDays() => _days;

    public float GettimeSpeed() => _timeSpeed;

    public WaitForSeconds GetDelay() => _delay;

    private void Start()
    {
        _delay = new WaitForSeconds(_secondsDelay);
        IsPlaying = true;
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
        while (IsPlaying)
        {
            _minutes += _secondsDelay * _timeSpeed;
            yield return _delay;
        }
    }
}
