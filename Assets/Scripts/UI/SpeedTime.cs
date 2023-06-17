using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeedTime : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _button;

    private bool _isSpeedMax;
    private readonly string _lowSpeed = "Ускорить время х60";
    private readonly string _maxSpeed = "Замедлить время х1";
    private readonly int _accelerationTime = 60;
    private readonly int _normalSpeedTime = 1;

    private void OnEnable()
    {
        _button.onClick.AddListener(CheckSpeed);
        _text.text = _lowSpeed;
        _text.color = Color.green;
        _isSpeedMax = false;
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(CheckSpeed);
    }
    private void CheckSpeed()
    {
        if (_isSpeedMax)
            ChangeParametrs(_lowSpeed, Color.green, _normalSpeedTime);
        else
            ChangeParametrs(_maxSpeed, Color.red, _accelerationTime);
    }

    private void ChangeParametrs(string text, Color color, int value)
    {
        _text.text = text;
        _text.color = color;
        _timer.SetSpeedTime(value);
        _isSpeedMax = !_isSpeedMax;
    }
}
