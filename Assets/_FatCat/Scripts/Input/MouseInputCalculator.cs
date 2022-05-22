using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputCalculator : InputCalculator
{
    private Mouse _currentMouse = null;
    private RaycastHit _hit;
    private Vector2 _inproperPosition = new Vector2(5000, 5000);

    public MouseInputCalculator(LayerMask mask, Mouse currentMouse) : base(mask)
    {
        _currentMouse = currentMouse;
    }

    public override Vector3 CalculatePosition()
    {
        if(_currentMouse == null)
        {
            return _inproperPosition;
        }

        var mousePos = _currentMouse.position.ReadValue();
        var ray = Camera.main.ScreenPointToRay(mousePos);

        if(Physics.Raycast(ray, out _hit, Mathf.Infinity, _mask))
        {
            return _hit.point;
        }
        else
        {
            // we should return some kind of WRONG position, so that we know that it is invalid...
            return _inproperPosition;
        }
    }
}
