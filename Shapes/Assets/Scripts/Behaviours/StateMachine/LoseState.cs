using Helpers;
using UI;

namespace Behaviours
{
    class LoseState : BaseState
    {
        public LoseState(GameStateController stateController) : base(stateController)
        {
            
        }
        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.LoseMenu);
        }
    }
}