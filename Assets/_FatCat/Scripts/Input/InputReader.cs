using InterfaceHolder;
using System;
using UnityEngine;

public class InputReader : MonoBehaviour, IInputReader
{
    public Vector2 InputWorldPos => _calculatedWorldPosition;

    Vector2 _calculatedWorldPosition;
    InputCalculator _inputCalculator = null;

    private void Awake()
    {
        ChonkerSettingsHolder.CurrentSettings.RegisterInterface<IInputReader>(this);

        InitInputCalculator();
    }

    private void InitInputCalculator()
    {
#if UNITY_EDITOR
        _inputCalculator = new MouseInputCalculator();
#endif

#if UNITY_ANDROID && !UNITY_EDITOR
        //TODO: create new touch input calculator
#endif
    }

    private void Update()
    {
        _calculatedWorldPosition = _inputCalculator.CalculatePosition();
    }
}
