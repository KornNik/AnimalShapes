using Helpers;

namespace Behaviours
{
    struct ChangeGameStateEvent
    {
        private static ChangeGameStateEvent _changeGameStateEvent;

        private GameStateType _nextGameState;

        public GameStateType NextGameState => _nextGameState;

        public static void Trigger(GameStateType nextGameState)
        {
            _changeGameStateEvent._nextGameState = nextGameState;
            EventManager.TriggerEvent(_changeGameStateEvent);
        }
    }
}
