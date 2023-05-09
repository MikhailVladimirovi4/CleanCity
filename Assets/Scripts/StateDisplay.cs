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

    private void Start()
    {
        _textMeshPro = GetComponent<TextMeshPro>();
    }

    private void FixedUpdate()
    {
        _textMeshPro.text = "Жителей " + Convert.ToString(_blockState.GetResidents()) + ". Мусорный бак заполнен на " + Convert.ToString(_blockState.GetTrashLevel()) + "%.";
    }
}
