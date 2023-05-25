using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaState : MonoBehaviour
{
    [SerializeField] private BlockState[] _blocks;

    public void OnService()
    {
        foreach (BlockState block in _blocks)
        {
            block.Includ();
        }
    }
}
