using Helpers;

namespace Behaviours
{
    enum ConstructEventType
    {
        None,
        Create,
        Destroy
    }
    struct ShapesConstructEvent
    {
        private static ShapesConstructEvent _constructEvent;
        
        private ConstructEventType _eventType;

        public ConstructEventType EventType => _eventType;
        
        public static void Trigger(ConstructEventType eventType)
        {
            _constructEvent._eventType = eventType;
            EventManager.TriggerEvent(_constructEvent);
        }
    }
}
