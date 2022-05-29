using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using UnityEngine.ResourceManagement.AsyncOperations;

[DefaultExecutionOrder(-9999)]
public class AddressablesIniter : MonoBehaviour
{
    public static event Action OnAddressablesInited; 

    private void Awake()
    {
        Addressables.InitializeAsync().Completed += HandleAddressablesInited;
    }

    void HandleAddressablesInited(AsyncOperationHandle<IResourceLocator> obj)
    {
        OnAddressablesInited?.Invoke();
    }
}
