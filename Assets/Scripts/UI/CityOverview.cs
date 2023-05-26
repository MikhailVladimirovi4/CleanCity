using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class CityOverview : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private Animator _animator;
    private Coroutine _changeTransform;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(AnimatorCityViewController.Params.OpenPanel);
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
