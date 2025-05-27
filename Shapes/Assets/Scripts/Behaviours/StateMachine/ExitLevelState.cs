using Helpers;
using System;
using Cysharp.Threading.Tasks;

namespace Behaviours
{
    sealed class ExitLevelState : BaseState
    {
        private ILevelLoader _levelLoader;
        public ExitLevelState(GameStateController stateController) : base(stateController)
        {
            _levelLoader = Services.Instance.LevelLoader.ServicesObject;
        }
        public override void EnterState()
        {
            base.EnterState();
            DeleteAll().Forget();
        }

        private async UniTaskVoid DeleteAll()
        {
            await LoadTask(DestroyShapes);
            await LoadTask(DeleteLevel);
            await LoadTask(StartMenuState);
        }
        private async UniTask LoadTask(Action loadingAction)
        {
            loadingAction?.Invoke();
            await UniTask.Yield();
        }
        private void DeleteLevel()
        {
            _levelLoader.ClearLevelFull();
        }

        private void DestroyShapes()
        {
            ShapesConstructEvent.Trigger(ConstructEventType.Destroy);
        }
        private void StartMenuState()
        {
            ChangeGameStateEvent.Trigger(GameStateType.MenuState);
        }
    }
}
