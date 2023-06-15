using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _trashRatePersonPerTime;
    [SerializeField] private StartGameInfo _startGameInfo;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _openGarage;
    [SerializeField] private Button _menu;
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

    private Wallet _wallet;

    public int IndexMinPeopleBlock => _indexStartPeopleBlock;
    public int ContractPrice => _contractPrice;
    public float CostsServisePeople => _costsServisePeople;
    public int IndexStartPeopleBlock => _indexStartPeopleBlock;
    public int GetTrashRatePerson => _trashRatePersonPerTime;
    public int TrachTrackPrice => _trachTrackPrice;
    public int ParkingPlacePrice => _parkingPlacePrice;
    public int UpLevelGaragePrice => _upLevelGaragePrice;
    public int PerCent { get; private set; } = 100;
    public int StartSupportBlock { get; private set; } = 50;
    public int StepAddSupportPeople { get; private set; } = 2;
    public int StepRemoveSupportPeople { get; private set; } = 10;

    private void Awake()
    {
        Time.timeScale = 0;
        _startGameInfo.gameObject.SetActive(true);
    }

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

    public void StartGame()
    {
        _wallet.AddCoins(_startingCoins);
        _menu.gameObject.SetActive(true);
        _startGameInfo.gameObject.SetActive(false);
        _timer.gameObject.SetActive(true);
        _openGarage.gameObject.SetActive(false);
        _offSoundButton.gameObject.SetActive(true);
        _backSound.Play();
        Time.timeScale = 1;
    }

    private void ShowVictory()
    {
        FinishGame();
        _firework.gameObject.SetActive(true);
    }

    private void ShowLosing()
    {
        FinishGame();
        Time.timeScale = 0;
        _gameOver.gameObject.SetActive(true);
    }

    private void FinishGame()
    {
        Debug.Log("STOP GAME");
        _backSound.Stop();
        _timer.Stop();
        _cityOverview.gameObject.SetActive(false);
        _garagePanel.gameObject.SetActive(false);
        _openGarage.gameObject.SetActive(false);
    }
}
