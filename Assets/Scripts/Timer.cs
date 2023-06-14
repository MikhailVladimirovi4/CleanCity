using System.Collections;
using UnityEngine;
using UnityEngine.Events;


public class Timer : MonoBehaviour
{
    [SerializeField] private TimeDisplay _display;

    private readonly int _secondsDelay = 1;
    private int _speedTime;
    private int _minutes;
    private int _hours;
    private int _days;
    private readonly int _dayWeek = 1;
    private readonly int _timeDay = 1440;
    private Coroutine _timeFlow;

    public event UnityAction DayIsOver;
    public event UnityAction<int> TimeChanged;
    public WaitForSeconds Delay { get; private set; }

    public bool IsPlaying { get; private set; }

    public int GetMinutes() => _minutes;
    public int GetHours() => _hours;
    public int GetDays() => _days;
    public int GetTimeDay() => _timeDay;

    public int SpeedTime => _speedTime;


    private void Awake()
    {
        Delay = new WaitForSeconds(_secondsDelay);
    }

    private void Start()
    {
        _speedTime = _secondsDelay;
        IsPlaying = true;
        _timeFlow = StartCoroutine(TimeFlow());
    }

    public void SetSpeedTime(int speedModifer)
    {
        _speedTime = speedModifer;
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
                    DayIsOver?.Invoke();
                }
            }
        }
    }

    IEnumerator TimeFlow()
    {
        while (IsPlaying)
        {
            _minutes += _secondsDelay * _speedTime;
            CountTime();
            _display.DisplayTime(_days, _hours, _minutes);
            TimeChanged?.Invoke(_speedTime);

            yield return Delay;
        }
    }
}
