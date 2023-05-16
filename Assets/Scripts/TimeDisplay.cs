using System;
using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private TextMeshPro _time;

    private void FixedUpdate()
    {
        _time.text = "Δενό " + Convert.ToString(_timer.GetDays()) + "\n" + Convert.ToString(_timer.GetHours()) + ":" + Convert.ToString(_timer.GetMinutes());
    }
}
