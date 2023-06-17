using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]

public class CityOverview : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private ListsAreasContract _listsContracts;
    [SerializeField] private Button _westTown;
    [SerializeField] private Button _ostTown;

    private Animator _animator;
    private Coroutine _changeTransform;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(AnimatorCityViewController.Params.OpenPanel);
        _listsContracts.gameObject.SetActive(false);
        _westTown.gameObject.SetActive(true);
        _ostTown.gameObject.SetActive(true);
    }

    public void Close()
    {
        if (_changeTransform != null)
            StopCoroutine(_changeTransform);

        _changeTransform = StartCoroutine(ChangeTransform());
    }

    private IEnumerator ChangeTransform()
    {
        int delay = 1;

        while (delay > 0)
        {
            _animator.SetTrigger(AnimatorCityViewController.Params.ClosePanel);
            delay--;

            yield return _timer.Delay;
        }

        gameObject.SetActive(false);
    }
}
