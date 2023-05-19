using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Office : MonoBehaviour
{
    [SerializeField] private Text _coin;
    [SerializeField] private Text _reputation;
    [SerializeField] private Text _garageLevel;
    [SerializeField] private Text _parkingPlace;
    [SerializeField] private Text _freeParkingPlace;
    [SerializeField] private Text _trashTrack;
    [SerializeField] private Text _freeTrashTrack;
    [SerializeField] private Wallet _wallet;

    private void OnEnable()
    {
        GetParametrs();
    }

    private void GetParametrs()
    {
        _coin.text = Convert.ToString(_wallet.Coints);
    }

    private void OnDisable()
    {
    }
}
