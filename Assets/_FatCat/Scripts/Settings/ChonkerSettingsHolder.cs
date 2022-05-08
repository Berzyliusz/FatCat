using UnityEngine;

namespace InterfaceHolder
{
    [CreateAssetMenu(fileName = "RocketSettingsHolder", menuName = "Settings/RocketSettingsHolder")]
    public class ChonkerSettingsHolder : SettingsHolder
    {
        private static bool _setOnce = false;
        [SerializeField] private ChonkerSettings _chonkerSettings = null;
        private ISettings<ChonkerSettings, ISettingsInfo> ChonkerSettings => _chonkerSettings;

        private static ChonkerSettingsSupplier _settingsSupplier = null;
        public static ISettings<ChonkerSettings, ISettingsInfo> CurrentSettings
        {
            get
            {
                if (_settingsSupplier == null && !_setOnce)
                {
                    GameObject settingsSupplierGO = new GameObject("SettingsSupplier");
                    _settingsSupplier = settingsSupplierGO.AddComponent<ChonkerSettingsSupplier>();
                    DontDestroyOnLoad(settingsSupplierGO);
                    ChonkerSettingsHolder rocketSettingsHolder = Resources.Load<ChonkerSettingsHolder>(typeof(ChonkerSettingsHolder).Name);
                    _settingsSupplier.SetSettingsHolder(rocketSettingsHolder);
                    _setOnce = true;
                }

                return _settingsSupplier.ChonkerSettingsHolder.ChonkerSettings.CurrentSettings;
            }
        }
    }

}