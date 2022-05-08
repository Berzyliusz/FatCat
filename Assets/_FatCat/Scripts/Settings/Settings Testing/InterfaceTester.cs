using UnityEngine;

namespace InterfaceHolder
{
    public class InterfaceTester : MonoBehaviour, ITestInterface
    {
        public bool Test()
        {
            Debug.Log("Interface system working");
            return true;
        }

        private void Awake()
        {
            ChonkerSettingsHolder.CurrentSettings.RegisterInterface<ITestInterface>(this);
        }

        private void Start()
        {
            ChonkerSettingsHolder.CurrentSettings.GetSettings<ITestInterface>().Test();
        }
    }
}
