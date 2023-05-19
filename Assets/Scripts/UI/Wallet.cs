using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int Coints { get; private set; }

    public void AddCoins(int value)
    {
        Coints += value;
    }

    public void RemoveCoins(int value)
    {
        Coints -= value;

        if (Coints < 0)
            Coints = 0;
    }
}
