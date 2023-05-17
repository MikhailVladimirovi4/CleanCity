using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    [SerializeField] private TimeDisplay _display;

    private readonly int _secondsDelay = 1;
    private int _timeSpeed;
    private int _minutes;
    private int _hours;
    private int _days;
    private readonly int _dayWeek = 1;
    private readonly int _timeDay = 1440;

    public WaitForSeconds Delay { get; private set; }

    public event UnityAction WeekIsOver;
    public event UnityAction<int> TimeChanged;
    private Coroutine _timeFlow;

    public bool IsPlaying { get; private set; }

    public int GetMinutes() => _minutes;
    public int GetHours() => _hours;
    public int GetDays() => _days;
    public int GetTimeDay() => _timeDay;

    public int GetTimeSpeed() => _timeSpeed;


    private void OnEnable()
    {
        Delay = new WaitForSeconds(_secondsDelay);
    }

    private void Start()
    {
        _timeSpeed = _secondsDelay;
        IsPlaying = true;
        _timeFlow = StartCoroutine(TimeFlow());
    }

    public void StartGame(int speedModifer)
    {
        _timeSpeed = speedModifer;
    }

    private void CountTime()
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
            CountTime();
            _display.DisplayTime(_days, _hours, _minutes);
            TimeChanged?.Invoke(_timeSpeed);

            yield return Delay;
        }
    }
}
