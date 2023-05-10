using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPozition : MonoBehaviour
{
    [SerializeField] private Transform _visor;

    private Vector3 _direction;

    private void FixedUpdate()
    {
        _direction = this.transform.position - _visor.position;
        this.transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);
    }
}
