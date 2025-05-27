using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch;

namespace Inputs
{
    sealed class TouchScreenInput : BaseInputs
    {
        private Finger _touch;

        public override void Initialization()
        {
            base.Initialization();
            EnhancedTouchSupport.Enable();
        }

        protected override Vector2 GetScreenInputPosition()
        {
            _touch = Touch.Touch.fingers.FirstOrDefault();
            var inputTouchPosition = _touch.currentTouch.screenPosition;
            var inputTouchPositionWithDepth = new Vector3(inputTouchPosition.x,
                inputTouchPosition.y, Mathf.Abs(Camera.transform.position.z));
            _screenClickPosition = Camera.ScreenToWorldPoint(inputTouchPositionWithDepth);
            return _screenClickPosition;
        }
        protected override Ray GetScreenInputRay()
        {
            _touch = Touch.Touch.fingers.FirstOrDefault();
            var inputTouchPosition = _touch.currentTouch.screenPosition;
            var ray = Camera.ScreenPointToRay(inputTouchPosition);
            return ray;
        }
        protected override bool IsTouchingPerform()
        {
            var isTouching = Touch.Touch.activeTouches.Count > 0;
            return isTouching;
        }
    }
}
