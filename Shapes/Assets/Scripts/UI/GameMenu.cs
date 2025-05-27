using Behaviours;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    sealed class GameMenu : BaseUI
    {
        [SerializeField] private Button _rebuildButton;

        private void OnEnable()
        {
            _rebuildButton.onClick.AddListener(OnRebuildButtonDown);
        }
        private void OnDisable()
        {
            _rebuildButton.onClick.RemoveListener(OnRebuildButtonDown);
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

        private void OnRebuildButtonDown()
        {
            ShapesConstructEvent.Trigger(ConstructEventType.Create);
        }
    }
}