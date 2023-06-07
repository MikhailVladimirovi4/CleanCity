using System.Linq;
using UnityEngine;

public class AreaState : MonoBehaviour
{
    [SerializeField] private BlockState[] _blocks;
    [SerializeField] private Transform[] _routeCollectPoints;
    [SerializeField] private Transform[] _routeLeavingArea;

    private int PerCent = 100;
    private int _trashIndexBlocksPerCent;

    public int PublicSupport { get; private set; }
    public int CurrentTrash { get; private set; }
    public int NumberPeople { get; private set; }
    public bool IsCollectionProgress { get; private set; }

    public int RouteCollectPoints => _routeCollectPoints.Length;
    public int RouteLeavingAreaPoints => _routeLeavingArea.Length;

    private void Start()
    {
        PublicSupport = 0;
        IsCollectionProgress = false;
        int trashMaxIndexBlocks = 0;

        foreach (BlockState block in _blocks)
            trashMaxIndexBlocks += block.TrashMaxIndex;

        _trashIndexBlocksPerCent = trashMaxIndexBlocks / PerCent;
    }

    public Transform GetRouteCollectPoint(int index) => _routeCollectPoints[index];
    public Transform GetRouteLeavingAreaPoint(int index) => _routeLeavingArea[index];
    public void OnCollectionProgress() => IsCollectionProgress = true;
    public void OffCollectionProgress() => IsCollectionProgress = false;

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
