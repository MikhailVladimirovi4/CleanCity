using UnityEngine;
using UnityEngine.UI;

public class BayInfo : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Button _ok;

    public void DisplayInfo(string text)
    {
        _text.text = text;
    }
}
