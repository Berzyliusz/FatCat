using InterfaceHolder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMovement : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 1.0f;
    [SerializeField] float _rotationSpeed = 1.0f;    

    IInputReader _inputReader = null;

    private void Start()
    {
        _inputReader = ChonkerSettingsHolder.CurrentSettings.GetSettings<IInputReader>();
    }

    private void FixedUpdate()
    {
        // check if mouse is properly placed, allow moving there

        var pos = _inputReader.InputWorldPos;
        var flatPos = new Vector3(pos.x, transform.position.y, pos.z);

        // rotate a little towards the point

        // add force in the forward direction

        // we need
    }
}
