using UnityEngine;
using UnityEngine.InputSystem;

namespace Inputs
{
    sealed class MouseInput : BaseInputs
    {
        public override void Initialization()
        {
            base.Initialization();
        }

        protected override Vector2 GetScreenInputPosition()
        {
            var inputMousePosition = Mouse.current.position.ReadValue();
            var inputMousePositionWithDepth = new Vector3(inputMousePosition.x,
                inputMousePosition.y, Mathf.Abs(_camera.transform.position.z));
            _screenClickPosition = Camera.ScreenToWorldPoint(inputMousePositionWithDepth);
            return inputMousePosition;
        }

        protected override Ray GetScreenInputRay()
        {
            var inputMousePosition = GetScreenInputPosition();
            var ray = Camera.ScreenPointToRay(inputMousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
            return ray;
        }
        protected override bool IsTouchingPerform()
        {
            bool isTouching = false;
            if (Mouse.current.leftButton.IsPressed())
            {
                isTouching = true;
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                isTouching = false;
            }
            return isTouching;
        }
    }
}
