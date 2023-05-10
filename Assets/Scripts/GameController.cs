using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private int _trashRatePersonPerTime;

    public int GetTrashRatePerson() => _trashRatePersonPerTime;
}
