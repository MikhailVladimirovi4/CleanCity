using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackState : MonoBehaviour
{
    [SerializeField] private int _residents;
    [SerializeField] private int _trashLevel;

    public int GetResidents() => _residents;
    public int GetTrashLevel() => _trashLevel;
}
