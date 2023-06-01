using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigator : MonoBehaviour
{
    private Transform _target;
    private Transform _nextTarget;

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public Transform GetTarget(string nameGameObject)
    {
        Transform target = null;

        switch (nameGameObject)
        {
            case "StartWorkPoint":

                break;

        }

        return target;
    }
}
