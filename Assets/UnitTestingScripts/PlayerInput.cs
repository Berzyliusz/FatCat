using UnityEngine;

namespace Assets.UnitTestingScripts
{
    public class PlayerInput : IPlayerInput
    {
        public float Vertical => Input.GetAxis("Vertical");
    }
}