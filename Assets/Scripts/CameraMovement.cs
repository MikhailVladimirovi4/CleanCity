using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionZ;
    [SerializeField] private float _minPositionZ;
    [SerializeField] private float _maxRotationY;
    [SerializeField] private float _minRotationY;
    [SerializeField] private int _speedRotation;
    [SerializeField] private int _speedMovement;

    private float _xRotation;
    private float _yRotation;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            UnityEngine.Cursor.visible = false;
            MoveMouse();
        }

        if (Input.GetMouseButtonUp(1))
        { 
            UnityEngine.Cursor.visible = true;
        }
    }

    private void MoveMouse()
    {
        _xRotation += Input.GetAxis("Mouse X") * _speedRotation * Time.deltaTime;
        _yRotation += Input.GetAxis("Mouse Y") * _speedRotation * -1 * Time.deltaTime;
        transform.rotation = Quaternion.Euler(_yRotation, _xRotation, 0f);
        _yRotation = Mathf.Clamp(_yRotation, _minRotationY, _maxRotationY);
    }
}
