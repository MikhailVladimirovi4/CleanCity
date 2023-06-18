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
    [SerializeField] private Info _info;
    [SerializeField] private TrackPark _trackPark;
    [SerializeField] private GarageState _garageState;
    [SerializeField] private AreasService _areasService;
    [SerializeField] private Timer _timer;

    private Wallet _wallet;
    private GameController _gameController;

    private void OnEnable()
    {
        _timer.DayIsOver += AddContractCoins;
    }

    private void OnDisable()
    {
        _timer.DayIsOver -= AddContractCoins;
        _info.gameObject.SetActive(false);
    }

    private void Start()
    {
        _info.gameObject.SetActive(false);
        _gameController = GetComponent<GameController>();
        _wallet = GetComponent<Wallet>();
    }

    private void FixedUpdate()
    {
        if (_timer.IsTimeFlow)
            UpdateValues();
    }

    public void Reset()
    {
        string startCount = "0";

        _reputationValue.text = startCount;
        _areasServiceCount.text = startCount;
        _population.text = startCount;
        _freeParkingPlace.text = startCount;
        _trashPerCent.text = startCount;
    }

    public void RunWork() => _trackPark.AllowTrackMove();
    public void StopWork() => _trackPark.BanTrackMove();

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
                    if (_trackPark.CurrentCountTrack < _garageState.Level || _garageState.Level == _garageState.MaxLevelGarage)
                    {
                        _wallet.RemoveCoins(_gameController.TrachTrackPrice);
                        _trackPark.AddTrashTrack();
                        text = "Мусоровоз доставлен в гараж.";
                    }
                    else
                    {
                        text = "Поднимите уровень станции.";
                    }
                }
                else
                {
                    text = "Оборудуйте дополнительное место парковки.";
                }
            }
        }
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
        DisplayRezultAction(text);
    }

    public void UpdateValues()
    {
        int places = _trackPark.CurrentCountPlace;
        int tracks = _trackPark.CurrentCountTrack;

        _coin.text = Convert.ToString(_wallet.Coints);
        _parkingPlace.text = Convert.ToString(places);
        _trashTrack.text = Convert.ToString(tracks);
        _freeParkingPlace.text = Convert.ToString(places - tracks);
        _freeTrashTrack.text = Convert.ToString(_trackPark.CountFreeTrack());

        if (_areasService.AreasCount > 0)
        {
            _reputationValue.text = Convert.ToString(_areasService.GetPublicSupport() + "%");
            _areasServiceCount.text = Convert.ToString(_areasService.AreasCount);
            _population.text = Convert.ToString(_areasService.GetPopulation());
            _trashPerCent.text = Convert.ToString(_areasService.GetTrashCount()) + "%";
        }

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
        _info.gameObject.SetActive(true);
        _info.DisplayInfo(text);
    }

    private void AddContractCoins()
    {
        float sumCoins;

        sumCoins = _areasService.GetPopulation() * _gameController.CostsServisePeople;
        _wallet.AddCoins((int)sumCoins);
    }
}
