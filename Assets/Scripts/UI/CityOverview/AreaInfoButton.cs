using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]

public class AreaInfoButton : MonoBehaviour
{
    [SerializeField] private AreaState _area;
    [SerializeField] private AreaInfoPanel _areaInfoPanel;
    [SerializeField] private AreasService _areaServise;

    private Image _image;
    private bool _isAdded;

    private void Start()
    {
        _image = GetComponent<Image>();
        _isAdded = false;
    }
    public void Action()
    {
        if (!_isAdded)
        {
            _areaServise.AddArea(_area);
            _image.color = Color.yellow;
            _area.OnService();
            _isAdded = true;
        }
        else
        {
            _areaInfoPanel.gameObject.SetActive(true);
            _areaInfoPanel.Init(_area);
        }
    }
}
