using UnityEngine;
using UnityEngine.InputSystem;

public class MouseInputCalculator : InputCalculator
{
    Mouse _currentMouse = null;

    public MouseInputCalculator(LayerMask mask, Mouse currentMouse) : base(mask)
    {
        _currentMouse = currentMouse;
    }

    public override Vector2 CalculatePosition()
    {
        var mousePos = _currentMouse.position.ReadValue();

        // If over UI, bail or give improper position?

        // Raycast for the floor position

        // Return raycast hit floor position

        return mousePos;
    }
}
