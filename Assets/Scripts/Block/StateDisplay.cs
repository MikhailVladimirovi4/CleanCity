using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]

public class StateDisplay : MonoBehaviour
{
    [SerializeField] private BlackState _blockState;
    [SerializeField] private Gradient _vertexColorGradient;
    [SerializeField, Range(0f, 1f)] private float _trashProgress;

    private TextMeshPro _textMeshPro;
    private int _trasherOneCent;
    private readonly int _perCent = 100;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        _trasherOneCent = _blockState.GetTrashMaxIndex() / _perCent;
    }

    private void FixedUpdate()
    {
        if (_trashProgress < _perCent)
            _trashProgress = _blockState.GetTrashCount() / _trasherOneCent;
        else
            _trashProgress = _perCent;
     
        _textMeshPro.text = "������� " + Convert.ToString(_blockState.GetResidents()) + ". �������� ��� �������� �� " + Convert.ToString(Convert.ToInt32(_trashProgress)) + "%.";
        _textMeshPro.color = _vertexColorGradient.Evaluate(_trashProgress / _perCent);
    }
}
