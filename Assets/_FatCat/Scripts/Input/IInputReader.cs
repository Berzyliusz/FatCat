using InterfaceHolder;
using UnityEngine;

public interface IInputReader : ISettingsInfo
{
    Vector2 InputWorldPos { get; }
}
