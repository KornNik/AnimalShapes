using UnityEngine;
using Helpers;
using Data;

namespace UI
{
    sealed class ScreenFactory
    {
        private Canvas _canvas;
        private GameMenu _gameMenu;
        private LoseMenu _loseMenu;
        private WinMenu _winMenu;
        private MainMenu _mainMenu;


        public ScreenFactory()
        {
            var resources = Services.Instance.DatasBundle.ServicesObject.
                GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.Canvas);
            _canvas = Object.Instantiate(resources, Vector3.one, Quaternion.identity).GetComponent<Canvas>();
        }

        public GameMenu GetGameMenu()
        {
            if (!_gameMenu)
            {
                var resources = Services.Instance.DatasBundle.ServicesObject.
                    GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.GameMenu);
                _gameMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<GameMenu>();
            }
            return _gameMenu;
        }

        public MainMenu GetMainMenu()
        {
            if (!_mainMenu)
            {
                var resources = Services.Instance.DatasBundle.ServicesObject.
                    GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.MainMenu);
                _mainMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<MainMenu>();
            }
            return _mainMenu;
        }

        public LoseMenu GetLoseMenu()
        {
            if (!_loseMenu)
            {
                var resources = Services.Instance.DatasBundle.ServicesObject.
                    GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.LoseMenu);
                _loseMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<LoseMenu>();
            }
            return _loseMenu;
        }
        public WinMenu GetWinMenu()
        {
            if (!_winMenu)
            {
                var resources = Services.Instance.DatasBundle.ServicesObject.
                    GetData<DataResourcePrefabs>().GetScreenPrefab(ScreenTypes.WinMenu);
                _winMenu = Object.Instantiate(resources, _canvas.transform.position,
                    Quaternion.identity, _canvas.transform).GetComponent<WinMenu>();
            }
            return _winMenu;
        }
    }
}