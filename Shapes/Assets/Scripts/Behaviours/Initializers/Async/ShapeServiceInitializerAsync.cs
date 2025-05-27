using Cysharp.Threading.Tasks;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class ShapeServiceInitializerAsync : IInitializationAsync
    {
        public async UniTask InitializationAsync()
        {
            var shapesCreatorPrefab = Services.Instance.DataResourcePrefabs.ServicesObject.
                GetShapesCreator();
            var shapesCreator = GameObject.Instantiate(shapesCreatorPrefab);

            Services.Instance.ShapesCreator.SetObject(shapesCreator);

            await UniTask.Yield();
        }
    }
}
