using InterfaceHolder;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class InputReader : MonoBehaviour, IInputReader
{
    [SerializeField] LayerMask _floorLayer = new LayerMask();
    public Vector3 InputWorldPos => _calculatedWorldPosition;

    [ShowInInspector]
    [ReadOnly]
    Vector3 _calculatedWorldPosition;
    InputCalculator _inputCalculator = null;

    private void Awake()
    {
        ChonkerSettingsHolder.CurrentSettings.RegisterInterface<IInputReader>(this);

        InitInputCalculator();
    }

    private void InitInputCalculator()
    {
//#if UNITY_EDITOR
        _inputCalculator = new MouseInputCalculator(_floorLayer, UnityEngine.InputSystem.Mouse.current);
//#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        //TODO: create new touch input calculator
#endif
    }

    private void Update()
    {
        _calculatedWorldPosition = _inputCalculator.CalculatePosition();
    }
}
