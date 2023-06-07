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
                int index = GetIndexAreaMaxTrash();

                if (index >= 0)
                {
                    _areaService.GetArea(index).OnCollectionProgress();
                    _trackParck.SendTrashTrack(_areaService.GetArea(index));
                }
            }
        }
    }
    private int GetIndexAreaMaxTrash()
    {
        int trashMaxCount = 0;
        int index = -1;

        for (int i = 0; i < _areaService.AreasCount; i++)
        {
            if (!_areaService.GetArea(i).IsCollectionProgress)
            {
                if (trashMaxCount <= _areaService.GetArea(i).CurrentTrashPerCent)
                {
                    trashMaxCount = _areaService.GetArea(i).CurrentTrashPerCent;
                    index = i;
                }
            }
        }
        return index;
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
