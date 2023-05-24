using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class BayPlaceButton : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Text _text;
    [SerializeField] private GameController _gameController;

    private Coroutine _showText;
    private readonly float _secondsDelay = 1;
    private WaitForSeconds _delay;

    private void Start()
    {
        _delay = new WaitForSeconds(_secondsDelay);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_showText != null)
            StopCoroutine(ShowPrice());

        _showText = StartCoroutine(ShowPrice());
    }

    IEnumerator ShowPrice()
    {
        int number = 1;

        _text.gameObject.SetActive(true);
        _text.text = "стоимость " + _gameController.ParkingPlacePrice;

        while (number > 0)
        {
            number--;

            yield return _delay;
        }

        _text.gameObject.SetActive(false);
    }
}
