using InterfaceHolder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerySimpleCatMovement : MonoBehaviour
{
    IInputReader _inputReader = null;

    private void Start()
    {
        _inputReader = ChonkerSettingsHolder.CurrentSettings.GetSettings<IInputReader>();
    }

    private void Update()
    {
        var pos = _inputReader.InputWorldPos;
        this.transform.position = pos;
    }
}
