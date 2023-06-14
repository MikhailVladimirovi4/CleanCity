using System.Linq;
using UnityEngine;

public class AreaState : MonoBehaviour
{
    [SerializeField] private BlockState[] _blocks;
    [SerializeField] private Transform[] _routeCollectPoints;
    [SerializeField] private Transform[] _routeLeavingArea;
    [SerializeField] private int _contractConditions;

    private readonly int PerCent = 100;
    private int _trashIndexBlocksPerCent;

    public int PublicSupport { get; private set; }
    public int CurrentTrashPerCent { get; private set; }
    public int NumberPeople { get; private set; }
    public bool IsCollectionProgress { get; private set; }
    public bool IsContract { get; private set; }

    public int ContractConditions => _contractConditions;
    public int RouteCollectPoints => _routeCollectPoints.Length;
    public int RouteLeavingAreaPoints => _routeLeavingArea.Length;

    public Transform GetRouteCollectPoint(int index) => _routeCollectPoints[index];
    public Transform GetRouteLeavingAreaPoint(int index) => _routeLeavingArea[index];
    public void OnCollectionProgress() => IsCollectionProgress = true;
    public void OffCollectionProgress() => IsCollectionProgress = false;


    private void Start()
    {
        PublicSupport = 0;
        IsCollectionProgress = false;
        IsContract = false;
        int trashMaxIndexBlocks = 0;

        foreach (BlockState block in _blocks)
            trashMaxIndexBlocks += block.TrashMaxIndex;

        _trashIndexBlocksPerCent = trashMaxIndexBlocks / PerCent;
    }

    private void FixedUpdate()
    {
        GetData();
    }

    public void CreateContract()
    {
        IsContract = true;
        OnService();
    }

    private void GetData()
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
        CurrentTrashPerCent = currentTrashblocks / _trashIndexBlocksPerCent;

        if (CurrentTrashPerCent > 100)
            CurrentTrashPerCent = 100;

        if (CurrentTrashPerCent < 0)
            CurrentTrashPerCent = 0;

        if (PublicSupport > 100)
            PublicSupport = 100;

        if (PublicSupport < 0)
            PublicSupport = 0;
    }

    private void OnService()
    {
        foreach (BlockState block in _blocks)
        {
            block.Includ();
        }
    }
}
