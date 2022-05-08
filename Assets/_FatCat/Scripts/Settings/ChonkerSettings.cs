using System;
using System.Collections.Generic;
using UnityEngine;
using ChoojlandGames;

[CreateAssetMenu(fileName = "RocketSettings", menuName = "Settings/RocketSettings")]
public class ChonkerSettings : Settings<ChonkerSettings, ISettingsInfo>
{
    protected Dictionary<Type, ISettingsInfo> _settingsInfoDict = new Dictionary<Type, ISettingsInfo>();

    public override ChonkerSettings CurrentSettings
    {
        get
        {
            if (_currentSettings == null)
            {
                _currentSettings = Instantiate(this);
                _currentSettings.InitializeSettings();
            }
            return _currentSettings;
        }
    }

    public override T GetSettings<T>()
    {
        if (!_settingsInfoDict.ContainsKey(typeof(T)))
        {
            Debug.LogError("Unregistered type requested from settings!");
            return default(T);
        }

        return (T)_settingsInfoDict[typeof(T)];
    }

    public override void RegisterInterface<T>(ISettingsInfo interfaceToRegister)
    {
        _settingsInfoDict[typeof(T)] = interfaceToRegister;
    }

    private void InitializeSettings()
    {

    }

    private ChonkerSettings _currentSettings { get; set; }
}
