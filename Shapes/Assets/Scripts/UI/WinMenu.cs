using Helpers;
using Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    sealed class WinMenu: BaseUI
    {
        [SerializeField] private Button _exitButton;
        
        private void OnEnable()
        {
            _exitButton.onClick.AddListener(OnExitButtonDown);
        }
        private void OnDisable()
        {
            _exitButton.onClick.RemoveListener(OnExitButtonDown);
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
    }
}