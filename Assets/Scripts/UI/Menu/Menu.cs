using System.Collections;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _continueGame;
    [SerializeField] private MenuButton _startGame;
    [SerializeField] private MenuButton _saveExit;
    [SerializeField] private Button _openMenu;
    [SerializeField] private GameController _controller;
    [SerializeField] private Button _confirm;
    [SerializeField] private Button _back;
    [SerializeField] private Timer _timer;

    private Coroutine _changeTransform;
    private Animator _animator;
    private string _nameAction;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(AnimatorMenuController.Params.OpenMenu);
    }

    public void Continue()
    {
        Return();

        if (_changeTransform != null)
            StopCoroutine(_changeTransform);

        _changeTransform = StartCoroutine(ChangeTransform());
    }

    public void ShowConfirm(string nameAction)
    {
        _nameAction = nameAction;
        _confirm.gameObject.SetActive(true);
        _back.gameObject.SetActive(true);
        _startGame.gameObject.SetActive(false);
        _continueGame.gameObject.SetActive(false);
        _saveExit.gameObject.SetActive(false);
    }

    public void Confirm()
    {
        switch (_nameAction)
        {
            case "StartGame":
                StartGame();
                break;

            case "SaveExit":
                SaveExit();
                break;
        }

        _nameAction = null;
    }

    public void Return()
    {
        _confirm.gameObject.SetActive(false);
        _back.gameObject.SetActive(false);
        _startGame.gameObject.SetActive(true);
        _continueGame.gameObject.SetActive(true);
        _saveExit.gameObject.SetActive(true);
    }

    private void StartGame()
    {
        _controller.StartGame();
    }

    private void SaveExit()
    {
        _controller.StartGame();
    }

    private IEnumerator ChangeTransform()
    {
        int delay = 1;

        while (delay > 0)
        {
            _animator.SetTrigger(AnimatorMenuController.Params.CloseMenu);
            delay--;

            yield return _timer.Delay;
        }

        gameObject.SetActive(false);
    }
}
