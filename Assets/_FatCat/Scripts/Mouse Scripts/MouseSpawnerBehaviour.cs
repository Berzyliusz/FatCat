using InterfaceHolder;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseSpawner : ISettingsInfo
{
    MouseSpawner MouseSpawner { get; }
}

public class MouseSpawnerBehaviour : MonoBehaviour, IMouseSpawner
{
    public MouseSpawner MouseSpawner { get; private set; }

    private void Awake()
    {
        ChonkerSettingsHolder.CurrentSettings.RegisterInterface<IMouseSpawner>(this);
    }

    private void Start()
    {
        MouseSpawner = new();
    }
}
