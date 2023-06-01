using System.Linq;
using UnityEngine;

public class AreaState : MonoBehaviour
{
    [SerializeField] private BlockState[] _blocks;
    [SerializeField] private Transform _collectStartPosition;

    private int PerCent = 100;
    private int _trashIndexBlocksPerCent;

    public int PublicSupport { get; private set; }
    public int CurrentTrash { get; private set; }
    public int NumberPeople { get; private set; }

    private void Start()
    {
        PublicSupport = 0;
        int trashMaxIndexBlocks = 0;

        foreach (BlockState block in _blocks)
            trashMaxIndexBlocks += block.TrashMaxIndex;

        _trashIndexBlocksPerCent = trashMaxIndexBlocks / PerCent;
    }

    public void OnService()
    {
        foreach (BlockState block in _blocks)
        {
            block.Includ();
        }
    }

    public void GetData()
    {
        int publicSupportblocks = 0;
        int currentTrashblocks = 0;
        NumberPeople = 0;

        foreach (BlockState block in _blocks)
        {
            publicSupportblocks += block.PublicSupportBlock;
            currentTrashblocks += block.TrashCount;
            NumberPeople += block.Residents;
        }

        PublicSupport = publicSupportblocks / _blocks.Count();
        CurrentTrash = currentTrashblocks / _trashIndexBlocksPerCent;
    }
}
