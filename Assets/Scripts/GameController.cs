using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _trashRatePersonPerTime;
    [SerializeField] private StartGameInfo _startGameInfo;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _openGarage;
    [SerializeField] private int _startingCoins;
    [SerializeField] private int _trachTrackPrice;
    [SerializeField] private int _parkingPlacePrice;
    [SerializeField] private int _contractPrice;
    [SerializeField] private float _costsServisePeople;
    [SerializeField] private int _upLevelGaragePrice;
    [SerializeField] private Button _offSoundButton;
    [SerializeField] private int _indexStartPeopleBlock;
    [SerializeField] private int _indexMinPeopleBlock;

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
        
    }

    private void OnDisable()
    {
        
    }

    public void StartGame()
    {
        _wallet.AddCoins(_startingCoins);
        _startGameInfo.gameObject.SetActive(false);
        _timer.gameObject.SetActive(true);
        _openGarage.gameObject.SetActive(false);
        _offSoundButton.gameObject.SetActive(true);
        Time.timeScale = 1;
    }
}
