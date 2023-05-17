using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _trashRatePersonPerTime;
    [SerializeField] private StartGameInfo _startGameInfo;

    public int GetTrashRatePerson() => _trashRatePersonPerTime;

    private void Awake()
    {
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        Time.timeScale = 1;
        _startGameInfo.gameObject.SetActive(false);
    }
}
