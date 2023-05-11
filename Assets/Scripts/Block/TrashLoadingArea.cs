using System.Collections;
using UnityEngine;

public class TrashLoadingArea : MonoBehaviour
{
    [SerializeField] private BlackState _blockState;

    private Coroutine _loadingTrash;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TrashTrack track))
        {
            if (_loadingTrash != null)
                StopCoroutine(_loadingTrash);

            _loadingTrash = StartCoroutine(LoadingTrash(track));
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out TrashTrack track))
        {
            if (_loadingTrash != null)
                StopCoroutine(_loadingTrash);
        }
    }

    IEnumerator LoadingTrash(TrashTrack track)
    {
        while (track.GetCargoSize() > track.GetCurrentTrash())
        {
            if (_blockState.GetTrashCount() > 0)
            {
                _blockState.RemoveTrash(track.GetLoadingSpeed());

                if (_blockState.GetTrashCount() > track.GetLoadingSpeed())
                    track.AddTrash(track.GetLoadingSpeed());
                else
                    track.AddTrash(_blockState.GetTrashCount());
            }
            yield return _blockState.GetDelay();
        }
    }
}
