using UnityEngine;

namespace InterfaceHolder
{
    [CreateAssetMenu(fileName = "ChonkerSettingsHolder", menuName = "Settings/ChonkerSettingsHolder")]
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
                    ChonkerSettingsHolder chonkerSettingsHolder = Resources.Load<ChonkerSettingsHolder>(typeof(ChonkerSettingsHolder).Name);
                    _settingsSupplier.SetSettingsHolder(chonkerSettingsHolder);
                    _setOnce = true;
                }

                return _settingsSupplier.ChonkerSettingsHolder.ChonkerSettings.CurrentSettings;
            }
        }
    }

}