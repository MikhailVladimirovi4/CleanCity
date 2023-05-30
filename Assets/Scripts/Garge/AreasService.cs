using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreasService : MonoBehaviour
{
    private List<AreaState> _areas = new List<AreaState>();

    public int AreasCount => _areas.Count;

    public void AddArea(AreaState area)
    {
        _areas.Add(area);
    }

    public int GetPopulation()
    {
        int count = 0;

        foreach(AreaState area in _areas)
        {
            area.GetData();
            count += area.NumberPeople;
        }

        return count;
    }

    public int GetTrashCount()
    {
        int count = 0;

        foreach (AreaState area in _areas)
        {
            area.GetData();
            count += area.CurrentTrash;
        }

        return count;
    }
}
