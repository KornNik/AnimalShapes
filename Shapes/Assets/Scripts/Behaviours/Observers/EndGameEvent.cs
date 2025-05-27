using Helpers;

namespace Behaviours
{
    struct EndGameEvent
    {
        private static EndGameEvent _endGameEvent;

        private EndGameEventType _eventType;

        public EndGameEventType EventType => _eventType; 

        public static void Trigger(EndGameEventType eventType)
        {
            _endGameEvent._eventType = eventType;
            EventManager.TriggerEvent(_endGameEvent);
        }
    }
}
