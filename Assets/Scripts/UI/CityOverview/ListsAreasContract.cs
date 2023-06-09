using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

public class ListsAreasContract : MonoBehaviour
{
    [SerializeField] private AreaInfoPanel[] _areaInfopanels;
    [SerializeField] private Text _townName;
    [SerializeField] private Town _town1;
    [SerializeField] private Town _town2;


    private void OnDisable()
    {
        for (int i = 0; i < _areaInfopanels.Length; i++)
            _areaInfopanels[i].ClearArea();
    }

    public void Init(int townIndex, string townName)
    {
        _townName.text = townName;

        if (townIndex > 0)
            CreateAreaInfoPanels(_town1);
        else
            CreateAreaInfoPanels(_town2);
    }

    private void CreateAreaInfoPanels(Town town)
    {
        for (int i = 0; i < _areaInfopanels.Length; i++)
            _areaInfopanels[i].Init(town.GetArea(i));
    }
}
