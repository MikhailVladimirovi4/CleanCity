using System.Collections;
using UnityEngine;

public class SpaceCargo : MonoBehaviour
{
    [SerializeField]  private int _cargoSize;
    [SerializeField]  private int _loadingSpeed;

    private int _currentTrash;
    private bool _isLoadingTrash;
    private bool _isFull;
    private Coroutine _loadingTrash;

    public bool IsFull => _isFull;
    public bool IsLoadingtrash => _isLoadingTrash;

    private void OnEnable()
    {
        _isFull = false;
        _isLoadingTrash = false;
    }

    private void RemoveTrash()
    {
        _currentTrash = 0;
        _isFull = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TrashLoadingBlock trashLoadingBlock))
        {
            if (_loadingTrash != null)
                StopCoroutine(_loadingTrash);

            _loadingTrash = StartCoroutine(LoadingTrash(trashLoadingBlock));
        }

        if (other.gameObject.TryGetComponent(out TrashDump trashDump))
        {
            RemoveTrash();
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

        while (!_isFull && _isLoadingTrash)
        {
            if (trashLoadingBlock.BlockTrashCount > 0)
            {
                trashLoadingBlock.BlockRemoveTrash(_loadingSpeed, out int trashcount, out bool isLoadingTrash);
                _currentTrash += trashcount;
                _isLoadingTrash = isLoadingTrash;
            }

            _isFull = (_cargoSize < _currentTrash);

            yield return trashLoadingBlock.TimeDelay;
        }

        _isLoadingTrash = false;
    }
}
