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

        foreach (AreaState area in _areas)
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

    public AreaState GetAreaMaxTrash()
    {
        int trashMaxCount = 0;
        int index = -1;

        for (int i = 0; i < _areas.Count; i++)
        {
            if (!_areas[i].IsCollectionProgress)
            {
                if (trashMaxCount <= _areas[i].CurrentTrash)
                {
                    trashMaxCount = _areas[i].CurrentTrash;
                    index = i;
                }
            }
        }
        if (index < 0)
            return null;
        else
            return _areas[index];
    }
}
