using System;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(TextMeshPro))]

public class StateDisplay : MonoBehaviour
{
    [SerializeField] private BlockState _blockState;
    [SerializeField] private Gradient _vertexColorGradient;
    [SerializeField, Range(0f, 1f)] private float _trashProgress;

    private TextMeshPro _textMeshPro;
    private int _trasherOneCent;
    private readonly int _perCent = 100;

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
        _trasherOneCent = _blockState.TrashMaxIndex / _perCent;
    }

    private void FixedUpdate()
    {
        float trashProgress;

        if (_trashProgress < _perCent)
           trashProgress = _blockState.TrashCount / _trasherOneCent;
        else
            trashProgress = _perCent;
     
        _textMeshPro.text = "Жителей " + Convert.ToString(_blockState.Residents) + ". Мусорный бак заполнен на " + Convert.ToString(trashProgress) + "%.";
        _textMeshPro.color = _vertexColorGradient.Evaluate(trashProgress / _perCent);
    }
}
