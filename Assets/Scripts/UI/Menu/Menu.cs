using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Animator))]

public class Menu : MonoBehaviour
{
    [SerializeField] private Button _continue;
    [SerializeField] private MenuButton _start;
    [SerializeField] private TMP_Text _startGameButtonText;
    [SerializeField] private Button _info;
    [SerializeField] private MenuButton _saveExit;
    [SerializeField] private Button _openMenu;
    [SerializeField] private GameController _controller;
    [SerializeField] private Button _confirm;
    [SerializeField] private Button _return;

    private Coroutine _changeTransform;
    private Animator _animator;
    private string _nameAction;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _animator.SetTrigger(AnimatorMenuController.Params.OpenMenu);
        _controller.PauseGame();

        if (_controller.IsPlaying)
            ShowButton(false, false, true, true, true, true);
        else
            ShowButton(false, false, true, true, false, false);

    }

    public void ShowConfirm(string nameAction)
    {
        if("StartGame" == nameAction && !_controller.IsPlaying)
        {
            _startGameButtonText.text = "Рестарт игры";
            StartGame();
        }

        _nameAction = nameAction;
        ShowButton(true, true, false, false, false, false);
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
        ShowButton(false, false, true, true, true, true);
    }
    public void ShowInfo()
    {
        Debug.Log("info");
    }

    private void StartGame()
    {
        _controller.StartGame();
        Close();
    }

    private void SaveExit()
    {
        Debug.Log("saveExit");
    }

    public void Close()
    {
        if (_changeTransform != null)
            StopCoroutine(_changeTransform);

        _changeTransform = StartCoroutine(ChangeTransform());
        _controller.PlayGame();
    }

    private void ShowButton(bool confirm = false, bool back = false, bool start = false, bool info = false, bool contin = false, bool saveExit = false)
    {
        _confirm.gameObject.SetActive(confirm);
        _return.gameObject.SetActive(back);
        _start.gameObject.SetActive(start);
        _info.gameObject.SetActive(info);
        _continue.gameObject.SetActive(contin);
        _saveExit.gameObject.SetActive(saveExit);
    }

    private IEnumerator ChangeTransform()
    {
        int delay = 1;

        while (delay > 0)
        {
            _animator.SetTrigger(AnimatorMenuController.Params.CloseMenu);
            delay--;

            yield return _controller.TimeDelay;
        }

        gameObject.SetActive(false);
        _openMenu.gameObject.SetActive(true);
    }
}
