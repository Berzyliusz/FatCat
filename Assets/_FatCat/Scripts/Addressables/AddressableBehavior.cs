using UnityEngine;

public class AddressableBehavior : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        AddressablesIniter.OnAddressablesInited += HandleAddressablesInited;
    }

    protected virtual void OnDisable()
    {
        AddressablesIniter.OnAddressablesInited -= HandleAddressablesInited;
    }

    protected virtual void HandleAddressablesInited()
    {
        
    }
}
