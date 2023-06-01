using System.Collections;
using UnityEngine;

public class SpaceCargo : MonoBehaviour
{
    private int _cargoSize;
    private int _loadingSpeed;
    private int _currentTrash;
    private bool _isLoadingTrash;
    private Coroutine _loadingTrash;

    public bool Full { get; private set; }

    public int CargoSize => _cargoSize;
    public int CurrentTrash => _currentTrash;

    private void OnEnable()
    {
        Full = false;
        _isLoadingTrash = false;
    }

    public void SetCargoSize(int spaceCargo) => _cargoSize = spaceCargo;
    public void SetLoadingSpeed(int loadingSpeed) => _loadingSpeed = loadingSpeed;

    private void RemoveTrash()
    {
        _currentTrash = 0;
        Full = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TrashLoadingBlock trashLoadingBlock))
        {
            if (_loadingTrash != null)
                StopCoroutine(_loadingTrash);

            _loadingTrash = StartCoroutine(LoadingTrash(trashLoadingBlock));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TrashLoadingBlock trashLoadingBlock))
        {
            if (_loadingTrash != null)
                StopCoroutine(_loadingTrash);
        }
    }

    IEnumerator LoadingTrash(TrashLoadingBlock trashLoadingBlock)
    {
        _isLoadingTrash = true;

        while (!Full && _isLoadingTrash)
        {
            if (trashLoadingBlock.BlockTrashCount > 0)
            {
                trashLoadingBlock.BlockRemoveTrash(_loadingSpeed, out int trashcount, out bool isLoadingTrash);
                _currentTrash += trashcount;
                _isLoadingTrash = isLoadingTrash;
            }

            Full = (_cargoSize < _currentTrash);

            yield return trashLoadingBlock.Timerdelay;
        }
    }
}
