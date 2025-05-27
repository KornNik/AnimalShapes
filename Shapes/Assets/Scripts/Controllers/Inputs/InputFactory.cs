using Inputs;
using UnityEngine;

namespace Behaviours
{
    sealed class InputFactory
    {
        public BaseInputs GetInputs()
        {
            if (Application.platform == RuntimePlatform.WindowsEditor)
            {
                return new MouseInput();
            }
            else
            {
                return new TouchScreenInput();
            }
        }
    }
}
