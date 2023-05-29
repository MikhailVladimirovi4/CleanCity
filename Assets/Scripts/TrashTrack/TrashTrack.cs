using UnityEngine;

public class TrashTrack : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _cargoSize;
    [SerializeField] private int _loadingSpeed;
    [SerializeField] private float _maxFuelTank;
    [SerializeField] private float _fuelConsumption;
    [SerializeField] private Timer _timer;

    private int _currentTrash;
    private Transform _targetMove;
    private Vector3 _startPosition;
    private readonly float _biasPozitionY = 0.5f;
    
    public bool IsFree { get; private set; }
    public int CargoSize => _cargoSize;
    public int CurrentTrash => _currentTrash;
    public int LoadingSpeed => _loadingSpeed;

    private void OnEnable()
    {
        _startPosition = new Vector3(transform.position.x, transform.position.y + _biasPozitionY, transform.position.z);
        transform.position = _startPosition;
        IsFree = true;
    }

    public void AddTrash(int addTrash)
    {
        if (_currentTrash < _cargoSize)
            _currentTrash += addTrash * _timer.GetTimeSpeed();
        else
            _currentTrash = _cargoSize;
    }

    public void RemoveTrash()
    {
        _currentTrash = 0;
    }
}
