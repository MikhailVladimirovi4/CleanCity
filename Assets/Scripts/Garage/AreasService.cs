using System.Collections.Generic;
using UnityEngine;

public class AreasService : MonoBehaviour
{
    [SerializeField] private List<AreaState> _areas = new List<AreaState>();

    public int AreasCount => _areas.Count;

    public AreaState GetArea(int index) => _areas[index];

    public void AddArea(AreaState area)
    {
        _areas.Add(area);
    }

    public int GetPopulation()
    {
        int count = 0;

        foreach (AreaState area in _areas)
        {
            count += area.NumberPeople;
        }

        return count;
    }

    public int GetTrashCount()
    {
        int count = 0;

        foreach (AreaState area in _areas)
        {
            count += area.CurrentTrashPerCent;
        }

        return count / _areas.Count;
    }

    public int GetPublicSupport()
    {
        int count = 0;

        foreach (AreaState area in _areas)
        {
            count += area.PublicSupport;
        }

        return count / _areas.Count;
    }
}
