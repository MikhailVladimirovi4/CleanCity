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
    [SerializeField] private Button _collectTrash;

    private AreaState _area;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void Init(AreaState area)
    {
        _area = area;
        UpdateData();

        if (_trackPark.CountFreeTrack() > 0)
            _collectTrash.gameObject.SetActive(true);
        else
            _collectTrash.gameObject.SetActive(false);

    }

    public void UpdateData()
    {
        _area.GetData();
        _publicSupport.text = Convert.ToString(_area.PublicSupport) + "%";
        _corentTrash.text = Convert.ToString(_area.CurrentTrash) + "%";
        _numberPeople.text = Convert.ToString(_area.NumberPeople);
    }

    public void CollectTrash()
    {
        _trackPark.SendTrashTrack(_area);
    }
}
