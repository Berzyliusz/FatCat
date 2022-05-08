using InterfaceHolder;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 1.0f;
    [SerializeField] float _rotationSpeed = 1.0f;

    Transform _myTransform = null;
    Rigidbody _rb = null;
    IInputReader _inputReader = null;

    private void Awake()
    {
        _myTransform = this.transform;
        _rb = this.GetComponent<Rigidbody>();
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
        var directionToTarget = flatPos - _myTransform.position;

        RotateToPointer(directionToTarget);
        MoveForward(directionToTarget);
    }

    private void RotateToPointer(Vector3 directionToTarget)
    {
        var targetRotation = Quaternion.LookRotation(directionToTarget);

        //_rb.freezeRotation = true;
        _myTransform.rotation = Quaternion.Slerp(_myTransform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
        //_rb.freezeRotation = false;
    }

    private void MoveForward(Vector3 directionToTarget)
    {
        var relativeForce = directionToTarget.normalized * _movementSpeed * Time.deltaTime;
        _rb.AddRelativeForce(relativeForce);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        if(_inputReader == null) { return; }

        Gizmos.color = Color.red;
        Gizmos.DrawSphere(_inputReader.InputWorldPos, 0.2f);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(_myTransform.position, _myTransform.forward);
    }
#endif
}
