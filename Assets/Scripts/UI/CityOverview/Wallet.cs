using UnityEngine;

public class Wallet : MonoBehaviour
{
    [SerializeField] private AudioSource _addCoin;
    [SerializeField] private AudioSource _removeCoin;

    public int Coints { get; private set; }

    public void AddCoins(int value)
    {
        Coints += value;
        _addCoin.Play();
    }

    public void RemoveCoins(int value)
    {
        if (Coints < 0)
        {
            Coints = 0;
        }
        else
        {
            Coints -= value;
            _removeCoin.Play();
        }
    }

    public void ResetCoins()
    {
        Coints = 0;
    }
}
