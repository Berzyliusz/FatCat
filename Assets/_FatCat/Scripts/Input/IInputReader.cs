using InterfaceHolder;
using UnityEngine;

public interface IInputReader : ISettingsInfo
{
    Vector3 InputWorldPos { get; }
}
