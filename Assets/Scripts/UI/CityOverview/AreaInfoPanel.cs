using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AreaInfoPanel : MonoBehaviour
{
    [SerializeField] private Text _publicSupport;
    [SerializeField] private Text _corentTrash;
    [SerializeField] private Text _numberPeople;
    [SerializeField] private TMP_Text _collectTrashText;
    [SerializeField] private TrackPark _trackPark;

    private AreaState _area;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Init(AreaState area)
    {
        _area = area;
        UpdateData();
    }

    public void UpdateData()
    {
        _area.GetData();
        _publicSupport.text = Convert.ToString(_area.PublicSupport) + "%";
        _corentTrash.text = Convert.ToString(_area.CurrentTrash) + "%";
        _numberPeople.text = Convert.ToString(_area.NumberPeople);

        if (_trackPark.IsFreeTrack())
            _collectTrashText.text = "собрать";
        else
            _collectTrashText.text = "нет машин";
    }

    public void CollectTrash()
    {
        _trackPark.SendTrashTrack(_area);
    }
}
