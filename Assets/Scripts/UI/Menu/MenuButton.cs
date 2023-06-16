using UnityEngine;

public class MenuButton : MonoBehaviour
{
    [SerializeField] Menu _menu;
    public void OnClick()
    {
        _menu.ShowConfirm(gameObject.name);
    }
}
