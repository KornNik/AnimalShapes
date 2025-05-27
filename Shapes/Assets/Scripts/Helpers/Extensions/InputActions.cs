using System.Collections.Generic;
using UnityEngine.InputSystem;

namespace Helpers.Extensions
{
    internal class InputActions
    {
        private Dictionary<string, InputAction> _playerActionList = new Dictionary<string, InputAction>();

        public Dictionary<string, InputAction> PlayerActionList => _playerActionList;

        public InputActions(InputActionMap playerActionMap)
        {
            InitializeActions(playerActionMap);
        }

        private void InitializeActions(InputActionMap playerActionMap)
        {
            _playerActionList.Add(InputActionManagerPlayer.MOVEMENT, playerActionMap.FindAction(InputActionManagerPlayer.MOVEMENT));
            _playerActionList.Add(InputActionManagerPlayer.LOOK, playerActionMap.FindAction(InputActionManagerPlayer.LOOK));
            _playerActionList.Add(InputActionManagerPlayer.INTERACT, playerActionMap.FindAction(InputActionManagerPlayer.INTERACT));
        }
    }
}
