using Helpers;
using UnityEngine;

namespace Behaviours
{
    struct ShapeEventInfo
    {
        public ShapeInfo ShapeInfo;
        public Shape Shape;

        public ShapeEventInfo(ShapeInfo shapeInfo, Shape shape)
        {
            ShapeInfo = shapeInfo;
            Shape = shape;
        }
    }
    struct ShapeSelectedComplete
    {
        private static ShapeSelectedComplete _selectedCompleteEvent;

        private ShapeEventInfo _shapeEventInfo;

        public ShapeEventInfo ShapeEventInfo => _shapeEventInfo;

        public static void Trigger(ShapeEventInfo shapeEventInfo)
        {
            _selectedCompleteEvent._shapeEventInfo = shapeEventInfo;
            EventManager.TriggerEvent(_selectedCompleteEvent);
        }
    }
}
