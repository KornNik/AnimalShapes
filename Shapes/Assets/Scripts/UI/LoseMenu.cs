using Behaviours;
using UnityEngine;
using UnityEngine.UI;
using Helpers;
using Data;

namespace UI
{
    sealed class LoseMenu : BaseUI
    {
        [Header("Buttons")]
        [SerializeField] private Button _exitButton;
        [SerializeField] private Button _reloadLevelButton;

        private void OnEnable()
        {
            _exitButton.onClick.AddListener(OnExitButtonDown);
            _reloadLevelButton.onClick.AddListener(OnReloadLevelButtonDown);
        }
        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(OnExitButtonDown);
            _reloadLevelButton.onClick.RemoveListener(OnReloadLevelButtonDown);
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
        }
        public override void Hide()
        {
            gameObject.SetActive(false);
            HideUI.Invoke();
        }

        private void OnExitButtonDown()
        {
            ChangeGameStateEvent.Trigger(GameStateType.ExitLevelState);
        }
        private void OnReloadLevelButtonDown()
        {
            ChangeGameStateEvent.Trigger(GameStateType.LoadLevelState);
        }
    }
}