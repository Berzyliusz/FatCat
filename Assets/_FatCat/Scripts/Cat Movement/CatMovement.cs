using UnityEngine;

public class CatMovement
{
    private Rigidbody _rb = null;
    private Transform _transform = null;

    private float _movementSpeed;
    private float _rotationSpeed;

    public CatMovement(Rigidbody rb, Transform transform, float movementSpeed, float rotationSpeed)
    {
        _rb = rb;
        _transform = transform;
        _movementSpeed = movementSpeed;
        _rotationSpeed = rotationSpeed;
    }

    public void OnTick(float deltaTime, Vector3 posToFollow)
    {
        var pos = posToFollow;
        var flatPos = new Vector3(pos.x, _transform.position.y, pos.z);
        var _directionToTarget = flatPos - _transform.position;

        RotateToPointer(_directionToTarget);
        MoveForward();
    }

    private void RotateToPointer(Vector3 directionToTarget)
    {
        var targetRotation = Quaternion.LookRotation(directionToTarget);

        //_rb.freezeRotation = true;
        _transform.rotation = Quaternion.Slerp(_transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        //_rb.freezeRotation = false;
    }

    private void MoveForward()
    {
        var relativeForce = _transform.forward.normalized * _movementSpeed * Time.deltaTime;
        //_rb.AddRelativeForce(relativeForce, ForceMode.Force);
        _rb.AddForce(relativeForce, ForceMode.Force);
    }
}
