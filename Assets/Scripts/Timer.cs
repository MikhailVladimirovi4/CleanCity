using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    [SerializeField] private int _secondsDelay;
    [SerializeField] private int _timeSpeed;

    private int _minutes;
    private int _hours;
    private int _days;
    private readonly int _dayWeek = 7;
    private readonly int _timeDay = 1440;
    private WaitForSeconds _delay;

    public event UnityAction WeekIsOver;
    private Coroutine _timeFlow;

    public bool IsPlaying { get; private set; }

    public int GetMinutes() => _minutes;
    public int GetHours() => _hours;
    public int GetDays() => _days;
    public int GetTimeDay() => _timeDay;

    public int GetTimeSpeed() => _timeSpeed;

    public WaitForSeconds GetDelay() => _delay;

    private void OnEnable()
    {
        IsPlaying = true;
        _delay = new WaitForSeconds(_secondsDelay);
    }

    private void Start()
    {
        _timeFlow = StartCoroutine(TimeFlow());
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

                if (_days % _dayWeek == 0)
                {
                    WeekIsOver?.Invoke();
                }
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
