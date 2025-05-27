using System;
using System.Collections.Generic;
using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    class ShapesContainer : IDisposable, IEventListener<ShapeSelectedComplete>
    {
        private List<Shape> _shapes;

        public ShapesContainer()
        {
            this.EventStartListening<ShapeSelectedComplete>();
        }
        public void Dispose()
        {
            _shapes = null;
            this.EventStopListening<ShapeSelectedComplete>();
        }

        public void FillShapes(List<Shape> shapes)
        {
            _shapes = shapes;
        }
        public void RemoveShape(Shape shape)
        {
            _shapes.Remove(shape);
            if (!IsShapesExist())
            {
                ShapesPlayingFieldClear.Trigger();
            }
        }
        public bool IsShapesExist()
        {
            return _shapes.Count > 0;
        }

        public void OnEventTrigger(ShapeSelectedComplete eventType)
        {
            RemoveShape(eventType.ShapeEventInfo.Shape);
        }
    }
}
