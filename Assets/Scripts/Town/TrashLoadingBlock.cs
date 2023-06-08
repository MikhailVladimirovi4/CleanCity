using UnityEngine;

public class TrashLoadingBlock : MonoBehaviour
{
    [SerializeField] private BlockState _blockState;

    public int BlockTrashCount => _blockState.TrashCount;

    public WaitForSeconds TimeDelay => _blockState.TimeDelay;

    public void BlockRemoveTrash(int loadingSpeed, out int sendTrashCount, out bool isSendTrash)
    {
        _blockState.RemoveTrash(loadingSpeed, out sendTrashCount, out  isSendTrash);
    }
}
