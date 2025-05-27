using UnityEngine;
using System;

namespace Inputs
{
    interface IInputEvents
    {
        event Action<Ray> RayProjected;
        event Action<Vector3> MousePosition;
    }
}
