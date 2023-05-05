using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayTime : MonoBehaviour
{
    [SerializeField] private Gradient _directionalLightGradient;
    [SerializeField] private Gradient _ambientLightGradient;
    [SerializeField, Range(1, 3600)] private float _timeDayInSeconds = 60;
    [SerializeField, Range(0f, 1f)] private float _timeProgress;
    [SerializeField] private Light _light;

    private Vector3 _defaultAngeles;

    private void Start() => _defaultAngeles = _light.transform.localEulerAngles;

    private void Update()
    {
        _timeProgress += Time.deltaTime / _timeDayInSeconds;

        if (_timeProgress > 1f)
            _timeProgress = 0f;

        _light.color = _directionalLightGradient.Evaluate(_timeProgress);
        RenderSettings.ambientLight = _directionalLightGradient.Evaluate(_timeProgress);
        _light.transform.localEulerAngles = new Vector3(_timeProgress, _defaultAngeles.x, _defaultAngeles.z);
    }
}
