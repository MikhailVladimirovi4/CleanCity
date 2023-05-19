using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _trashRatePersonPerTime;
    [SerializeField] private StartGameInfo _startGameInfo;
    [SerializeField] private Office _office;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private Timer _timer;
    [SerializeField] private int _startingCoins;

    public int GetTrashRatePerson() => _trashRatePersonPerTime;

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
    }
}
