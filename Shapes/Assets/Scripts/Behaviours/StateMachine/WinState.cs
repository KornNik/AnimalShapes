using Helpers;
using Inputs;
using UI;

namespace Behaviours
{
    class WinState : BaseState
    {
        public WinState(GameStateController stateController) : base(stateController)
        {
            
        }

        public override void EnterState()
        {
            ScreenInterface.GetInstance().Execute(ScreenTypes.WinMenu);
        }
    }
}