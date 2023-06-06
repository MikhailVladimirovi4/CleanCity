using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TrackPark))]
[RequireComponent(typeof(AreasService))]

public class TrashCollectionAutomat : MonoBehaviour
{
    [SerializeField] private Button _onButton;
    [SerializeField] private Button _offButton;

    private AreasService _areaService;
    private TrackPark _trackParck;
    [SerializeField] private bool _isWorks;

    private void Start()
    {
        _trackParck = GetComponent<TrackPark>();
        _areaService = GetComponent<AreasService>();
    }

    private void FixedUpdate()
    {
        if (_isWorks)
        {
            if (_trackParck.IsFreeTrack() != null)
            {
                AreaState area = _areaService.GetAreaMaxTrash();

                if (area != null)
                    _trackParck.SendTrashTrack(area);
            }
        }
    }

    public void On()
    {
        _isWorks = true;
        _onButton.gameObject.SetActive(false);
        _offButton.gameObject.SetActive(true);
    }

    public void Off()
    {
        _isWorks = false;
        _onButton.gameObject.SetActive(true);
        _offButton.gameObject.SetActive(false);
    }
}
