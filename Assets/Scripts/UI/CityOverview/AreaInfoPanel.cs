using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AreaInfoPanel : MonoBehaviour
{
    [SerializeField] private Text _publicSupport;
    [SerializeField] private Text _corentTrash;
    [SerializeField] private Text _numberPeople;
    [SerializeField] private Text _contractCost;
    [SerializeField] private Text _contractText;
    [SerializeField] private TrackPark _trackPark;
    [SerializeField] private Button _collectTrash;
    [SerializeField] private GarageState _garageState;
    [SerializeField] private TMP_Text _contractInfo;
    [SerializeField] private Button _contractButton;

    [SerializeField] private AreaState _area;

    public void Init(AreaState area)
    {
        _area = area;
        _contractCost.text = Convert.ToString(_area.ContractCost);
        UpdateData();

        if (_trackPark.CountFreeTrack() > 0)
        {
            _contractText.gameObject.SetActive(false);
            _collectTrash.gameObject.SetActive(true);
        }
        else
        {
            _collectTrash.gameObject.SetActive(false);
            _contractText.gameObject.SetActive(true);
        }

        if (_garageState.Level >= _area.ContractConditions)
        {
            _contractInfo.text = "Условия для Контракта выполнены !  Контракт?";
            SetColorContractButton(Color.green);
        }
        else
        {
            _contractInfo.text = "Условия для Контракта не выполнены ! Поднимите уровень станции.";
            SetColorContractButton(Color.red);
        }
    }

    public void ClearArea()
    {
        _area = null;
    }

    public void UpdateData()
    {
        _area.GetData();
        _publicSupport.text = Convert.ToString(_area.PublicSupport) + "%";
        _corentTrash.text = Convert.ToString(_area.CurrentTrashPerCent) + "%";
        _numberPeople.text = Convert.ToString(_area.NumberPeople);
    }

    public void CollectTrash()
    {
        _trackPark.SendTrashTrack(_area);
    }

    public void TakeContract()
    {
        _area.CreateContract();
    }

    private void SetColorContractButton(Color color)
    {
        ColorBlock colorBlock = _contractButton.colors;
        colorBlock.normalColor = color;
        colorBlock.highlightedColor = color;
        colorBlock.pressedColor = color;
        colorBlock.selectedColor = color;
        colorBlock.disabledColor = color;
        _contractButton.colors = colorBlock;
    }
}
