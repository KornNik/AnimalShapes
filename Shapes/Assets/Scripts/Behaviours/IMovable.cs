using UnityEngine;

namespace Behaviours
{
    interface IMovable
    {
        void Move(Vector3 movement);
    }
    interface IMovableVector2
    {
        void Move(Vector2 movement);
    }
}
