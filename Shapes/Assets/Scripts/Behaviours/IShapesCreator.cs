using UnityEngine;

namespace Behaviours
{
    interface IShapesCreator
    {
        public void CreateAndPlace(Transform activatePoint);
    }
}
