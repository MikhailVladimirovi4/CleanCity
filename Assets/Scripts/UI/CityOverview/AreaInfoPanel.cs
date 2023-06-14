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
    [SerializeField] private CollectTrashButton _collectTrash;
    [SerializeField] private GarageState _garageState;
    [SerializeField] private TMP_Text _contractInfo;
    [SerializeField] private Button _contractButton;
    [SerializeField] private AreasService _areaServise;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private TrackPark _trackPark;
    [SerializeField] private GameController _controller;

private AreaState _area;

    private void FixedUpdate()
    {
        if (_area.IsContract)
        {
            UpdateData();
            SetMessageCollectButton();
        }
    }
    public void CollectTrash()
    {
        if (_trackPark.IsFreeTrack)
            _trackPark.SendTrashTrack(_area);
    }

    public void Init(AreaState area)
    {
        _area = area;

        if (!area.IsContract)
        {
            ShowDetals(true, false, true);
            _contractCost.text = Convert.ToString(_controller.ContractPrice);

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
        else
        {
            ShowDetals(false, true, false);
        }
    }

    public void ClearArea()
    {
        _area = null;
    }

    public void TakeContract()
    {
        if (_garageState.Level >= _area.ContractConditions)
        {
            if (_wallet.Coints < _controller.ContractPrice)
            {
                _contractInfo.text = "Не хватает монет!";
            }
            else
            {
                _wallet.RemoveCoins(_controller.ContractPrice);
                _area.CreateContract();
                _areaServise.AddArea(_area);
                ShowDetals(false, true, false);
            }
        }
    }

    private void UpdateData()
    {
        _publicSupport.text = Convert.ToString(_area.PublicSupport) + "%";
        _corentTrash.text = Convert.ToString(_area.CurrentTrashPerCent) + "%";
        _numberPeople.text = Convert.ToString(_area.NumberPeople);
    }

    private void ShowDetals(bool contractText, bool collectButton, bool contratButton)
    {
        _contractText.gameObject.SetActive(contractText);
        _collectTrash.gameObject.SetActive(collectButton);
        _contractButton.gameObject.SetActive(contratButton);
    }

    private void SetMessageCollectButton()
    {
        if (_trackPark.IsFreeTrack)
            _collectTrash.ShowMessage("Отпавить мусоровоз");
        else
            _collectTrash.ShowMessage("Нет свободных машин");
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
