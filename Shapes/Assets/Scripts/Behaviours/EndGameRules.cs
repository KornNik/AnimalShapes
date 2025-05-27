using Helpers;
using System;
using UnityEngine;

namespace Behaviours
{
    class EndGameRules :  IDisposable, IEventListener<ShapesPlacesFullEvent>,
        IEventListener<ShapesPlayingFieldClear>
    {
        public EndGameRules()
        {
            this.EventStartListening<ShapesPlacesFullEvent>();
            this.EventStartListening<ShapesPlayingFieldClear>();
        }
        public void Dispose()
        {
            this.EventStopListening<ShapesPlacesFullEvent>();
            this.EventStopListening<ShapesPlayingFieldClear>();
        }

        private void GameIsLost()
        {
            ChangeGameStateEvent.Trigger(GameStateType.LoseState);
        }
        private void GameIsWon()
        {
            ChangeGameStateEvent.Trigger(GameStateType.WinState);
        }

        public void OnEventTrigger(ShapesPlacesFullEvent eventType)
        {
            Debug.Log("Game Lost");
            GameIsLost();
            EndGameEvent.Trigger(EndGameEventType.Lost);
        }

        public void OnEventTrigger(ShapesPlayingFieldClear eventType)
        {
            Debug.Log("Game Won");
            GameIsWon();
            EndGameEvent.Trigger(EndGameEventType.Win);
        }
    }
}
