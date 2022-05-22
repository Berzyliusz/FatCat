using InterfaceHolder;
using UnityEngine;

public interface ICatMovement : ISettingsInfo
{
    Vector3 CatPosition { get; }
    //Vector3 CatForward { get; }
    Vector3 CatVelocity { get; }
}

public class CatMovementBehaviour : MonoBehaviour, ICatMovement
{
    [SerializeField] float _movementSpeed = 1.0f;
    [SerializeField] float _rotationSpeed = 1.0f;

    Transform _myTransform = null;
    Rigidbody _rb = null;
    IInputReader _inputReader = null;
    Vector3 _directionToTarget = Vector3.zero;
    CatCollisionProcessor _collisionProcessor = null;
    CatMovement _catMovement = null;

    public Vector3 CatPosition => _myTransform.position;
    public Vector3 CatVelocity => _rb.velocity;

    private void Awake()
    {
        _myTransform = this.transform;
        _rb = this.GetComponent<Rigidbody>();
        _collisionProcessor = new(_rb);
        _catMovement = new(_rb, _myTransform, _movementSpeed, _rotationSpeed);

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

        _catMovement.OnTick(Time.deltaTime, _inputReader.InputWorldPos);
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
