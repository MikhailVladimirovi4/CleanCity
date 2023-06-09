using UnityEngine;
using UnityEngine.UI;

public class TownViewButton : MonoBehaviour
{
    [SerializeField] private int index;
    [SerializeField] private ListsAreasContract _areasContract;
    [SerializeField] private Text _townName;
    [SerializeField] private Button _town1Button;
    [SerializeField] private Button _town2Button;

    public void On()
    {
        _areasContract.gameObject.SetActive(true);
        _areasContract.Init(index, _townName.text);
        _town1Button.gameObject.SetActive(false);
        _town2Button.gameObject.SetActive(false);
    }
}
