using System;
using UnityEngine;
using UnityEngine.UI;

public class Office : MonoBehaviour
{
    [SerializeField] private Text _coin;
    [SerializeField] private Text _reputationValue;
    [SerializeField] private Text _garageLevel;
    [SerializeField] private Text _parkingPlace;
    [SerializeField] private Text _freeParkingPlace;
    [SerializeField] private Text _trashTrack;
    [SerializeField] private Text _freeTrashTrack;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private BayInfo _bayInfo;
    [SerializeField] private TrackPark _trackPark;
    [SerializeField] private GameController _gameController;
    [SerializeField] private GarageState _garageState;

    private int _reputation = 0;


    private void OnEnable()
    {
        UpdateValues();
        _bayInfo.gameObject.SetActive(false);

    }

    private void OnDisable()
    {

    }

    public void UpLevel()
    {
        string text;

        if (_wallet.Coints < _gameController.UpLevelGaragePrice)
        {
            text = "Недостаточно средств для улучшения станции";
        }
        else
        {
            if (_garageState.Level < _garageState.MaxLevelGarage)
            {
                _wallet.RemoveCoins(_gameController.UpLevelGaragePrice);
                _garageState.UpLevel();
                text = "Произведено улучшение станции.";
            }
            else
            {
                _garageLevel.text = "MAX";
                text = "Уровень станции максимальный";
            }
        }

        UpdateValues();
        DisplayRezultAction(text);
    }

    public void AddTrack()
    {

    }

    public void AddPlace()
    {

    }

    private void UpdateValues()
    {
        _coin.text = Convert.ToString(_wallet.Coints);
        _reputationValue.text = Convert.ToString(_reputation);
        _parkingPlace.text = Convert.ToString(_trackPark.GetPlaceCount());
        _trashTrack.text = Convert.ToString(_trackPark.GetTrackCount());

        if (_garageState.Level == _garageState.MaxLevelGarage)
            _garageLevel.text = "MAX";
        else
            _garageLevel.text = Convert.ToString(_garageState.Level);
    }

    private void DisplayRezultAction(string text)
    {
        UpdateValues();
        _bayInfo.gameObject.SetActive(true);
        _bayInfo.DisplayInfo(text);
    }
}
