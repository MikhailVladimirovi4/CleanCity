using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _trashRatePersonPerTime;
    [SerializeField] private StartGameInfo _startGameInfo;
    [SerializeField] private Office _office;
    [SerializeField] private Timer _timer;

    public int GetTrashRatePerson() => _trashRatePersonPerTime;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        _startGameInfo.gameObject.SetActive(false);
        _office.gameObject.SetActive(true);
        _timer.gameObject.SetActive(true);
    }
}
