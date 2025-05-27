using Inputs;
using System;
using Helpers.Managers;
using UnityEngine;

namespace Behaviours
{
    sealed class ShapeClick : IEventSubscription, IDisposable
    {
        private IInputEvents _inputEvents;
        private RaycastHit2D[] _hits2D;

        public ShapeClick(IInputEvents inputEvents)
        {
            _hits2D = new RaycastHit2D[2];
            _inputEvents = inputEvents;
            Subscribe();
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        public void Subscribe()
        {
            _inputEvents.MousePosition += OnMousePosition;
        }
        public void Unsubscribe()
        {
            _inputEvents.MousePosition -= OnMousePosition;
        }
        private void OnMousePosition(Vector3 position)
        {
            var hits = Physics2D.RaycastNonAlloc(new Vector2(position.x, position.y), Vector2.zero,  _hits2D,
                0f, LayerMask.GetMask(LayersManager.SHAPE));
            if (hits > 0)
            {
                if(_hits2D[0].collider.GetComponent<Shape>() is ISelectable selectable)
                {
                    selectable.Select();
                }
            }
        }
    }
}
