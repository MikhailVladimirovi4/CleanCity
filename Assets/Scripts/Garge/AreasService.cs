using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreasService : MonoBehaviour
{
    private List<AreaState> _areas = new List<AreaState>();

    public void AddArea(AreaState area)
    {
        _areas.Add(area);
    }
}
