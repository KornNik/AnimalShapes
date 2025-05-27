using System;
using Helpers;

namespace UI
{
    sealed class ScreenInterface : IDisposable
    {
        private BaseUI _currentWindow;
        private readonly ScreenFactory _screenFactory;
        private static ScreenInterface _instance;

        private ScreenInterface()
        {
            _screenFactory = new ScreenFactory();
        }

        public BaseUI CurrentWindow => _currentWindow;

        public static ScreenInterface GetInstance()
        {
            return _instance ??= new ScreenInterface();
        }

        public void Execute(ScreenTypes screenType)
        {
            if (CurrentWindow)
            {
                CurrentWindow.Hide();
            }

            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _currentWindow = _screenFactory.GetGameMenu();
                    break;
                case ScreenTypes.MainMenu:
                    _currentWindow = _screenFactory.GetMainMenu();
                    break;
                case ScreenTypes.WinMenu:
                    _currentWindow = _screenFactory.GetWinMenu();
                    break;
                case ScreenTypes.LoseMenu:
                    _currentWindow = _screenFactory.GetLoseMenu();
                    break;
                default:
                    break;
            }

            CurrentWindow.Show();
        }

        public void AddObserver(ScreenTypes screenType, IListenerScreen listenerScreen)
        {
            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _screenFactory.GetGameMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetGameMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetGameMenu().Hide();
                    break;
                case ScreenTypes.MainMenu:
                    _screenFactory.GetMainMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetMainMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetMainMenu().Hide();
                    break;
                case ScreenTypes.WinMenu:
                    _screenFactory.GetWinMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetWinMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetWinMenu().Hide();
                    break;
                case ScreenTypes.LoseMenu:
                    _screenFactory.GetLoseMenu().ShowUI += listenerScreen.ShowScreen;
                    _screenFactory.GetLoseMenu().HideUI += listenerScreen.HideScreen;
                    _screenFactory.GetLoseMenu().Hide();
                    break;
                default:
                    break;
            }
        }

        public void RemoveObserver(ScreenTypes screenType, IListenerScreen listenerScreen)
        {
            switch (screenType)
            {
                case ScreenTypes.GameMenu:
                    _screenFactory.GetGameMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetGameMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetGameMenu().Hide();
                    break;
                case ScreenTypes.MainMenu:
                    _screenFactory.GetMainMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetMainMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetMainMenu().Hide();
                    break;
                case ScreenTypes.WinMenu:
                    _screenFactory.GetWinMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetWinMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetWinMenu().Hide();
                    break;
                case ScreenTypes.LoseMenu:
                    _screenFactory.GetLoseMenu().ShowUI -= listenerScreen.ShowScreen;
                    _screenFactory.GetLoseMenu().HideUI -= listenerScreen.HideScreen;
                    _screenFactory.GetLoseMenu().Hide();
                    break;
                default:
                    break;
            }
        }

        public void Dispose()
        {
            _instance = null;
        }
    }
}
