using InterfaceHolder;
using UnityEngine;

public interface ICatMovement : ISettingsInfo
{
    Vector3 CatPosition { get; }
    //Vector3 CatForward { get; }
    Vector3 CatVelocity { get; }
}

public class CatMovement : MonoBehaviour, ICatMovement
{
    [SerializeField] float _movementSpeed = 1.0f;
    [SerializeField] float _rotationSpeed = 1.0f;

    Transform _myTransform = null;
    Rigidbody _rb = null;
    IInputReader _inputReader = null;
    Vector3 _directionToTarget = Vector3.zero;
    CatCollisionProcessor _collisionProcessor = null;

    public Vector3 CatPosition => _myTransform.position;
    public Vector3 CatVelocity => _rb.velocity;

    private void Awake()
    {
        _myTransform = this.transform;
        _rb = this.GetComponent<Rigidbody>();

        _collisionProcessor = new CatCollisionProcessor(_rb);
        ChonkerSettingsHolder.CurrentSettings.RegisterInterface<ICatMovement>(this);
    }

    private void Start()
    {
        _inputReader = ChonkerSettingsHolder.CurrentSettings.GetSettings<IInputReader>();
    }

    private void Update()
    {
        // check if mouse is properly placed, allow moving there
        // check if can move, collision or something?

        var pos = _inputReader.InputWorldPos;
        var flatPos = new Vector3(pos.x, transform.position.y, pos.z);
        _directionToTarget = flatPos - _myTransform.position;

        RotateToPointer(_directionToTarget);
        MoveForward();
    }

    private void RotateToPointer(Vector3 directionToTarget) //TODO: Move to POCO
    {
        var targetRotation = Quaternion.LookRotation(directionToTarget);

        //_rb.freezeRotation = true;
        _myTransform.rotation = Quaternion.Slerp(_myTransform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        //_rb.freezeRotation = false;
    }

    private void MoveForward() //TODO: Move to POCO
    {
        var relativeForce = _myTransform.forward.normalized * _movementSpeed * Time.deltaTime;
        //_rb.AddRelativeForce(relativeForce, ForceMode.Force);
        _rb.AddForce(relativeForce, ForceMode.Force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        _collisionProcessor.HandleCollision(collision);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if(_inputReader == null) { return; }

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_inputReader.InputWorldPos, 0.2f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_myTransform.position, _directionToTarget);
    }
#endif
}
