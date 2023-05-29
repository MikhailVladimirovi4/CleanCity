using System.Collections;
using UnityEngine;

public class TrashLoadingBlock : MonoBehaviour
{
    [SerializeField] private BlockState _blockState;
    [SerializeField] private Timer _timer;

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
        while (track.CargoSize > track.CurrentTrash)
        {
            if (_blockState.TrashCount > 0)
            {
                _blockState.RemoveTrash(track.LoadingSpeed);

                if (_blockState.TrashCount > track.LoadingSpeed)
                    track.AddTrash(track.LoadingSpeed);
                else
                    track.AddTrash(_blockState.TrashCount);
            }

            yield return _timer.Delay;
        }
    }
}
