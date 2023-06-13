using UnityEngine;
using UnityEngine.UI;

public class CollectTrashButton : MonoBehaviour
{
    [SerializeField] private Text _message;

    public void ShowMessage(string text) => _message.text = text;
}
