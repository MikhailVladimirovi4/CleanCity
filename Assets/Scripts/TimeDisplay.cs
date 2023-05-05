using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]

public class TimeDisplay : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private TextMeshPro _textMeshPro;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void FixedUpdate()
    {
        _textMeshPro.text = "Δενό " + Convert.ToString(_timer.GetDays()) + "\n" + Convert.ToString(_timer.GetHours()) + ":" + Convert.ToString(_timer.GetMinutes());
    }
}
