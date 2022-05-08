using InterfaceHolder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 1.0f;
    [SerializeField] float _rotationSpeed = 1.0f;

    Transform _myTransform = null;
    IInputReader _inputReader = null;

    private void Awake()
    {
        _myTransform = this.transform;
    }

    private void Start()
    {
        _inputReader = ChonkerSettingsHolder.CurrentSettings.GetSettings<IInputReader>();
    }

    private void FixedUpdate()
    {
        // check if mouse is properly placed, allow moving there
        // check if can move, collision or something?

        RotateToPointer();

        // add force in the forward direction

        // we need
    }

    private void RotateToPointer()
    {
        var pos = _inputReader.InputWorldPos;
        var flatPos = new Vector3(pos.x, transform.position.y, pos.z);
        var directionToTarget = flatPos - _myTransform.position;
        var targetRotation = Quaternion.LookRotation(directionToTarget);

        // we should freeze RB?
        _myTransform.rotation = Quaternion.Slerp(_myTransform.rotation, targetRotation, _rotationSpeed);
        // we can unfreeze the RB now
    }
}
