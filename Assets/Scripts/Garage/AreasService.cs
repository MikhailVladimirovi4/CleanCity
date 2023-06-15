using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreasService : MonoBehaviour
{
    private readonly List<AreaState> _areas = new List<AreaState>();

    public event UnityAction Won;
    public event UnityAction Lost;

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
        int result;

        foreach (AreaState area in _areas)
        {
            count += area.PublicSupport;
        }

        result = count / _areas.Count;

        if (result >= 100)
            Won?.Invoke();

        if(result <= 0)
            Lost?.Invoke();

        return result;
    }
}
