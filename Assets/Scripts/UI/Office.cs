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
    [SerializeField] private Text _areasServiceCount;
    [SerializeField] private Text _population;
    [SerializeField] private Text _trashPerCent;

    [SerializeField] private Wallet _wallet;
    [SerializeField] private Info _info;
    [SerializeField] private TrackPark _trackPark;
    [SerializeField] private GameController _gameController;
    [SerializeField] private GarageState _garageState;
    [SerializeField] private AreasService _areasService;


    private int _reputation = 0;


    private void OnEnable()
    {
        UpdateValues();
        _info.gameObject.SetActive(false);
    }

    private void Start()
    {
        gameObject.SetActive(false);
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
                text = "Уровень станции максимальный";
            }
        }

        UpdateValues();
        DisplayRezultAction(text);
    }

    public void AddTrack()
    {
        string text;

        if (_wallet.Coints < _gameController.TrachTrackPrice)
        {
            text = "Недостаточно средств для приобретения мусоровоза.";
        }
        else
        {
            if (_trackPark.CurrentCountTrack == _trackPark.MaxCountPlace)
            {
                text = "Гараж максимально укомплектован техникой.";
            }
            else
            {
                if (_trackPark.CurrentCountTrack < _trackPark.CurrentCountPlace)
                {
                    _wallet.RemoveCoins(_gameController.TrachTrackPrice);
                    _trackPark.AddTrashTrack();
                    text = "Мусоровоз доставлен в гараж.";
                }
                else
                {
                    text = "Оборудуйте дополнительное место парковки.";
                }
            }
        }
        UpdateValues();
        DisplayRezultAction(text);
    }

    public void AddPlace()
    {
        string text;

        if (_wallet.Coints < _gameController.ParkingPlacePrice)
        {
            text = "Недостаточно средств на расширение парковки.";
        }
        else
        {
            if (_trackPark.CurrentCountPlace < _trackPark.MaxCountPlace)
            {
                _wallet.RemoveCoins(_gameController.ParkingPlacePrice);
                _trackPark.AddPlace();
                text = "Открыто дополнительное место парковки.";
            }
            else
            {
                text = "Открыты все места на парковке.";
            }
        }
        UpdateValues();
        DisplayRezultAction(text);
    }

    public void UpdateValues()
    {
        int places = _trackPark.CurrentCountPlace;
        int tracks = _trackPark.CurrentCountTrack;

        _coin.text = Convert.ToString(_wallet.Coints);
        _reputationValue.text = Convert.ToString(_reputation);
        _parkingPlace.text = Convert.ToString(places);
        _trashTrack.text = Convert.ToString(tracks);
        _areasServiceCount.text = Convert.ToString(_areasService.AreasCount);
        _population.text = Convert.ToString(_areasService.GetPopulation());
        _trashPerCent.text = Convert.ToString(_areasService.GetTrashCount()) + "%";
        _freeParkingPlace.text = Convert.ToString(places - tracks);
        _freeTrashTrack.text = Convert.ToString(_trackPark.CountFreeTrack());


        if (_garageState.Level == _garageState.MaxLevelGarage)
        {
            _garageLevel.text = "MAX";
            _garageLevel.fontSize = 50;
        }
        else
        {
            _garageLevel.text = Convert.ToString(_garageState.Level);
        }
    }

    private void DisplayRezultAction(string text)
    {
        UpdateValues();
        _info.gameObject.SetActive(true);
        _info.DisplayInfo(text);
    }
}
