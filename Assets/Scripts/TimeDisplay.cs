using System;
using TMPro;
using UnityEngine;

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshPro _time;

    public void DisplayTime(int days, int hours, int minutes)
    {
        _time.text = "Δενό " + Convert.ToString(days) + "\n" + Convert.ToString(hours) + ":" + Convert.ToString(minutes);
    }
}
