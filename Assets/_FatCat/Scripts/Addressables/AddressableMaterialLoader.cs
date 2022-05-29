using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddressableMaterialProcessor
{
    public AddressableMaterialProcessor(MeshRenderer rend, AssetReferenceMaterial addressable)
    {
        addressable.LoadAssetAsync<Material>().Completed += (material) =>
        {
            rend.material = material.Result;
        };
    }
}

public class AddressableMaterialLoader : AddressableBehavior
{
    [SerializeField] AddressableMaterial[] _addressableMaterials = new AddressableMaterial[0];

    protected override void HandleAddressablesInited()
    {
        foreach(var addressableMat in _addressableMaterials)
        {
            new AddressableMaterialProcessor(addressableMat.Renderer, addressableMat.MaterialReference);
        }
    }
}
