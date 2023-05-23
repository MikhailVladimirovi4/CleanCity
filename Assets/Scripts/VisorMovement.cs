using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class VisorMovement : MonoBehaviour
{
    [SerializeField] private float _maxPositionX;
    [SerializeField] private float _minPositionX;
    [SerializeField] private float _maxPositionY;
    [SerializeField] private float _minPositionY;
    [SerializeField] private float _maxPositionZ;
    [SerializeField] private float _minPositionZ;
    [SerializeField] private float _maxRotationX;
    [SerializeField] private float _minRotationX;
    [SerializeField] private float _smoothRotate;
    [SerializeField] private int _mouseSensitivity;
    [SerializeField] private int _speedMovement;

    private float _rotationX;
    private float _rotationY;
    private float _moveX;
    private float _moveZ;
    private CharacterController _visor;
    private Vector3 _moveDirection;
    private bool _isOpenOffice;
    private Transform _startTransform;

    private void OnEnable()
    {
        _visor = GetComponent<CharacterController>();
        _startTransform = GetComponent<Transform>();
        Debug.Log(gameObject.transform);
        _isOpenOffice = true;
    }

    private void Update()
    {
        if (!_isOpenOffice)
            ChangeTransform();
    }

    public void BanMove() => _isOpenOffice = true;
    public void AllowMove() => _isOpenOffice = false;
    public void ResetPosition()
    {
        gameObject.transform.position = _startTransform.position;
        gameObject.transform.rotation = _startTransform.rotation;
    }

    private void ChangeTransform()
    {
        if (Input.GetMouseButton(1))
        {
            UnityEngine.Cursor.visible = false;
            Move();
            Rotate();
        }

        if (Input.GetMouseButtonUp(1))
        {
            UnityEngine.Cursor.visible = true;
        }
    }

    private void Move()
    {
        _moveX = Input.GetAxis("Horizontal");
        _moveZ = Input.GetAxis("Vertical");
        _moveDirection = this.transform.TransformDirection(new Vector3(_moveX, 0f, _moveZ));
        _visor.Move(_moveDirection * Time.deltaTime * _speedMovement);

        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, _minPositionX, _maxPositionX), Mathf.Clamp(this.transform.position.y, _minPositionY, _maxPositionY), Mathf.Clamp(this.transform.position.z, _minPositionZ, _maxPositionZ));
    }

    private void Rotate()
    {
        _rotationX += Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSensitivity;
        _rotationY += Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSensitivity;
        _rotationY = Mathf.Clamp(_rotationY, _minRotationX, _maxRotationX);
        this.transform.rotation = Quaternion.Euler(-_rotationY, _rotationX, 0f);
    }
}
