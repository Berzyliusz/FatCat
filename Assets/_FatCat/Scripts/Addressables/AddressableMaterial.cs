using UnityEngine;

[System.Serializable]
public struct AddressableMaterial
{
    public MeshRenderer Renderer;
    public AssetReferenceMaterial MaterialReference;

    public void Release(GameObject go)
    {
        MaterialReference.ReleaseAsset();
        MaterialReference.ReleaseInstance(go);
    }
}
