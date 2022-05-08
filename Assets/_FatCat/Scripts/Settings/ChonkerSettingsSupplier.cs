using UnityEngine;

namespace InterfaceHolder
{
    public class ChonkerSettingsSupplier : MonoBehaviour
    {
        private ChonkerSettingsHolder _chonkerSettingsHolder = null;

        public ChonkerSettingsHolder ChonkerSettingsHolder => _chonkerSettingsHolder;

        public void SetSettingsHolder(ChonkerSettingsHolder rocketSettingsHolder)
        {
            _chonkerSettingsHolder = Instantiate(rocketSettingsHolder);
        }
    }
}