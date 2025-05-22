using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class ShapesBuilder
    {
        private Shape _currentBuildingShape;

        private CertainPool<Shape> _shapesPool;

        public ShapesBuilder(ShapesBundle shapesBundle, Transform spawnPoint, ShapeType shape)
        {
            _shapesPool = new CertainPool<Shape>(shapesBundle.ShapesCount/3, spawnPoint,
                shapesBundle.Shapes[shape].ShapePrefab);
        }

        public ShapesBuilder CreateShape()
        {
            var shape = _shapesPool.GetObject();
            _currentBuildingShape = shape as Shape;
            return this;
        }
        public ShapesBuilder WithColor(Color color)
        {
            _currentBuildingShape.SetColor(color);
            return this;
        }
        public ShapesBuilder WithImage(DataInsideImage dataImage)
        {
            _currentBuildingShape.SetInsideImage(dataImage.ImageSprite);
            return this;
        }
        public ShapesBuilder WithPosition(Vector3 position)
        {
            _currentBuildingShape.transform.position = position;
            return this;
        }
        public ShapesBuilder WithRotation(Quaternion rotation)
        {
            _currentBuildingShape.transform.rotation = rotation;
            return this;
        }
        public Shape Build()
        {
            return _currentBuildingShape;
        }
    }
}
