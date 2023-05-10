using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour
{
    [SerializeField] private Gradient _directionalLightGradient;
    [SerializeField] private Gradient _ambientLightGradient;
    [SerializeField, Range(0f, 1f)] private float _timeProgress;
    [SerializeField] private Light _light;
    [SerializeField] private Timer _timer;

    private Vector3 _defaultAngeles;
    private readonly float _turnIntex = 360f;
    private readonly float _timeDayInSeconds = 1440;

    private void Start() => _defaultAngeles = _light.transform.localEulerAngles;

    private void Update()
    {
        if (_timer.IsPlaying)
            _timeProgress += Time.deltaTime / _timeDayInSeconds * _timer.GettimeSpeed();

        if (_timeProgress > 1f)
            _timeProgress = 0f;

        _light.color = _directionalLightGradient.Evaluate(_timeProgress);
        RenderSettings.ambientLight = _directionalLightGradient.Evaluate(_timeProgress);
        _light.transform.localEulerAngles = new Vector3(_turnIntex * _timeProgress, _defaultAngeles.x, _defaultAngeles.z);
    }
}
