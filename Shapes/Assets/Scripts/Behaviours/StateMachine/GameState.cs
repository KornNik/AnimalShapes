using Helpers;
using Inputs;
using UI;

namespace Behaviours
{
    sealed class GameState : BaseState
    {
        private BaseInputs _baseInputs;
        private ShapeClick _shapeClick;
        private EndGameRules _endGameRules;

        public GameState(GameStateController stateController) : base(stateController)
        {
            _baseInputs = new InputFactory().GetInputs();
            _shapeClick = new ShapeClick(_baseInputs);
            _endGameRules = new EndGameRules();
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.GameMenu);
        }

        public override void LogicUpdate()
        {
            _baseInputs.Update();
        }
    }
}
