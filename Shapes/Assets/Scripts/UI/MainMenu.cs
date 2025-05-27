using UnityEngine;
using UnityEngine.UI;
using Data;
using Helpers;
using Behaviours;

namespace UI
{
    sealed class MainMenu : BaseUI
    {
        [Header("Buttons")]
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _quitGameButton;
        [Header("Tween")]
        [SerializeField] private RectTransform _rectTransform;
        [SerializeField] private CanvasGroup _canvasGroup;
        
        private DefaultScreenTweens _screenTweens;

        protected override void Awake()
        {
            base.Awake();

            var tweenSettings = Services.Instance.DatasBundle.ServicesObject.
                GetData<TweensSettingsBundle>().
                GetTweenSettings(TweenSettingsType.ScreenDefaultSettings);
            var anchorsSettings = Services.Instance.DatasBundle.ServicesObject.
                GetData<TweensSettingsBundle>().GetAnchorsSettings(ScreenAnchorsTweenType.TopToBottom);

            _screenTweens = new DefaultScreenTweens(_rectTransform, _canvasGroup,
                tweenSettings, anchorsSettings, this.gameObject);
        }

        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(OnStartButtonDown);
            _quitGameButton.onClick.AddListener(OnQuitGameButtonDown);
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(OnStartButtonDown);
            _quitGameButton.onClick.RemoveListener(OnQuitGameButtonDown);
        }

        private void OnDestroy()
        {
            _screenTweens.Dispose();
        }

        public override void Show()
        {
            gameObject.SetActive(true);
            ShowUI.Invoke();
            _screenTweens.Show();
        }
        public override void Hide()
        {
            _screenTweens.Hide();
            HideUI.Invoke();
        }

        private void OnStartButtonDown()
        {
            ChangeGameStateEvent.Trigger(GameStateType.LoadLevelState);
        }
        private void OnQuitGameButtonDown()
        {
            Application.Quit();
        }
    }
}