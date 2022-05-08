using UnityEngine;

public abstract class InputCalculator
{
    protected LayerMask _mask = new LayerMask();

    public InputCalculator(LayerMask mask)
    {
        _mask = mask;
    }

    public abstract Vector3 CalculatePosition();
}
