using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _trashRatePersonPerTime;
    [SerializeField] private Menu _menu;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _openGarage;
    [SerializeField] private Button _menuButton;
    [SerializeField] private int _startingCoins;
    [SerializeField] private int _trachTrackPrice;
    [SerializeField] private int _parkingPlacePrice;
    [SerializeField] private int _contractPrice;
    [SerializeField] private float _costsServisePeople;
    [SerializeField] private int _upLevelGaragePrice;
    [SerializeField] private Button _offSoundButton;
    [SerializeField] private int _indexStartPeopleBlock;
    [SerializeField] private int _indexMinPeopleBlock;
    [SerializeField] private AudioSource _backSound;
    [SerializeField] private AreasService _areaService;
    [SerializeField] private Firework _firework;
    [SerializeField] private GameOver _gameOver;
    [SerializeField] private GaragePanel _garagePanel;
    [SerializeField] private CityOverview _cityOverview;
    [SerializeField] private ListsAreasContract _listsContracts;
    [SerializeField] private VisorMovement _visor;
    [SerializeField] private GarageState _garageState;

    private Wallet _wallet;
    private readonly int _numberAllAreas = 16;
    public readonly int PerCent = 100;
    public readonly int StartSupportBlock = 50;
    public readonly int StepAddSupportPeople = 2;
    public readonly int StepRemoveSupportPeople = 10;

    public int IndexMinPeopleBlock => _indexStartPeopleBlock;
    public int ContractPrice => _contractPrice;
    public float CostsServisePeople => _costsServisePeople;
    public int IndexStartPeopleBlock => _indexStartPeopleBlock;
    public int GetTrashRatePerson => _trashRatePersonPerTime;
    public int TrachTrackPrice => _trachTrackPrice;
    public int ParkingPlacePrice => _parkingPlacePrice;
    public int UpLevelGaragePrice => _upLevelGaragePrice;
    public WaitForSeconds TimeDelay => _timer.Delay;
    public bool IsPlaying { get; private set; }


    private void OnEnable()
    {
        _wallet = GetComponent<Wallet>();
        _areaService.Won += ShowVictory;
        _areaService.Lost += ShowLosing;
    }

    private void OnDisable()
    {
        _areaService.Won -= ShowVictory;
        _areaService.Lost -= ShowLosing;
    }

    private void Start()
    {
        _menu.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        IsPlaying = true;
        _wallet.ResetCoins();
        _wallet.AddCoins(_startingCoins);
        _areaService.ResetState();
        _garageState.ResetState();
        _timer.ResetTime();
        _offSoundButton.gameObject.SetActive(true);
        PauseGame();
    }

    public void PlayGame()
    {
        _backSound.Play();
        _garagePanel.gameObject.SetActive(true);
        _timer.Run();
        _visor.AllowMove();
    }
    public void PauseGame()
    {
        _backSound.Stop();
        _timer.Stop();
        _visor.BanMove();
        _openGarage.gameObject.SetActive(false);
        _garagePanel.gameObject.SetActive(false);
        _cityOverview.gameObject.SetActive(false);
        _listsContracts.gameObject.SetActive(false);
    }

    private void ShowVictory()
    {
        if (_numberAllAreas <= _areaService.AreasCount)
        {
            FinishGame();
            _firework.gameObject.SetActive(true);
        }
    }

    private void ShowLosing()
    {
        FinishGame();
        Time.timeScale = 0;
        _gameOver.gameObject.SetActive(true);
    }

    private void FinishGame()
    {
        _backSound.Stop();
        IsPlaying = false;
        _timer.Stop();
        _cityOverview.gameObject.SetActive(false);
        _garagePanel.gameObject.SetActive(false);
        _openGarage.gameObject.SetActive(false);
    }
}
