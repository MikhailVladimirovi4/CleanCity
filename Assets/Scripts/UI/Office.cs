using System;
using UnityEngine;
using UnityEngine.UI;

public class Office : MonoBehaviour
{
    [SerializeField] private Text _coin;
    [SerializeField] private Text _reputationValue;
    [SerializeField] private Text _garageLevel;
    [SerializeField] private Text _parkingPlace;
    [SerializeField] private Text _freeParkingPlace;
    [SerializeField] private Text _trashTrack;
    [SerializeField] private Text _freeTrashTrack;
    [SerializeField] private Wallet _wallet;
    [SerializeField] private BayInfo _bayInfo;
    [SerializeField] private TrackPark _trackPark;

    private int _reputation = 0;


    private void OnEnable()
    {
        UpdateValues();
        _bayInfo.gameObject.SetActive(false);

    }

    private void OnDisable()
    {

    }

    public void UpLevel()
    {
        _bayInfo.gameObject.SetActive(true);
        _bayInfo.DisplayInfo("Поздравляю! \n Гараж преобразован. Теперь он вмещает больше мусоровозов.");
    }

    public void AddTrack()
    {
        _bayInfo.gameObject.SetActive(true);
        _bayInfo.DisplayInfo("By Track.");
    }

    public void AddPlace()
    {
        _bayInfo.gameObject.SetActive(true);
        _bayInfo.DisplayInfo("BayPlace.");
    }

    private void UpdateValues()
    {
        _coin.text = Convert.ToString(_wallet.Coints);
        _parkingPlace.text = Convert.ToString(_trackPark.GetPlaceCount());
        _trashTrack.text = Convert.ToString(_trackPark.GetTrackCount());
        _reputationValue.text = Convert.ToString(_reputation);
    }
}
