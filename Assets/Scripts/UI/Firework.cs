using System.Collections;
using UnityEngine;

public class Firework : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] _lists;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private Timer _timer;

    private Coroutine _corutine;
    private bool _isVictory;

    private void OnEnable()
    {
        _isVictory = true;

        if (_corutine != null)
            StopCoroutine(_corutine);

        _corutine = StartCoroutine(Victory());

    }

    private void OnDisable()
    {
        _isVictory = false;
    }

    IEnumerator Victory()
    {
        while (_isVictory)
        {
            for (int i = 0; i < _lists.Length; i++)
            {
                if (!_lists[i].gameObject.activeSelf)
                    _lists[i].gameObject.SetActive(true);

                _sound.Play();
                Debug.Log("salut");

                yield return _timer.Delay;
            }
        }
    }
}
