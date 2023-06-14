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
    [SerializeField] private int _upLevelGaragePrice;
    [SerializeField] private Button _offSoundButton;
    [SerializeField] private int _indexStartPeopleBlock;

    public int IndexStartPeopleBlock => _indexStartPeopleBlock;
    public int GetTrashRatePerson => _trashRatePersonPerTime;
    public int TrachTrackPrice => _trachTrackPrice;
    public int ParkingPlacePrice => _parkingPlacePrice;
    public int UpLevelGaragePrice => _upLevelGaragePrice;
    public int PerCent { get; private set; }

    private void Awake()
    {
        Time.timeScale = 0;
        _startGameInfo.gameObject.SetActive(true);
        PerCent = 100;
    }

    public void StartGame()
    {
        _wallet.AddCoins(_startingCoins);
        Time.timeScale = 1;
        _startGameInfo.gameObject.SetActive(false);
        _timer.gameObject.SetActive(true);
        _openGarage.gameObject.SetActive(false);
        _offSoundButton.gameObject.SetActive(true);
    }
}
