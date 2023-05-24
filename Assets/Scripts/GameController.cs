using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _trashRatePersonPerTime;
    [SerializeField] private StartGameInfo _startGameInfo;
    [SerializeField] private Office _office;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Timer _timer;
    [SerializeField] private Button _openGarage;
    [SerializeField] private int _startingCoins;
    [SerializeField] private int _trachTrackPrice;
    [SerializeField] private int _parkingPlacePrice;
    [SerializeField] private int _upLevelGaragePrice;
    [SerializeField] private Button _offSoundButton;

    public int GetTrashRatePerson => _trashRatePersonPerTime;
    public int TrachTrackPrice => _trachTrackPrice;
    public int ParkingPlacePrice => _parkingPlacePrice;
    public int UpLevelGaragePrice => _upLevelGaragePrice;

    private void Awake()
    {
        Time.timeScale = 0;
        _startGameInfo.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        _wallet.AddCoins(_startingCoins);
        Time.timeScale = 1;
        _startGameInfo.gameObject.SetActive(false);
        _office.gameObject.SetActive(true);
        _timer.gameObject.SetActive(true);
        _openGarage.gameObject.SetActive(false);
        _offSoundButton.gameObject.SetActive(true);
    }
}
