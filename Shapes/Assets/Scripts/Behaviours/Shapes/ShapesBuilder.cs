using Data;
using Helpers;
using UnityEngine;

namespace Behaviours
{
    sealed class ShapesBuilder
    {
        private Shape _currentBuildingShape;
        private DataMainShape _dataMainShape;

        private CertainPool<Shape> _shapesPool;
        private ShapesBundle _shapesBundle;

        public ShapesBuilder(ShapesBundle shapesBundle, Transform spawnPoint, ShapeType shape)
        {
            _shapesBundle = shapesBundle;
            _dataMainShape = _shapesBundle.Shapes[shape];
            _shapesPool = new CertainPool<Shape>(_shapesBundle.ShapesCount/3, spawnPoint,
                _dataMainShape.ShapePrefab);
        }

        public void Clear()
        {
            _shapesPool.ReturnAllToPool();
        }
        public void DestroyPool()
        {
            _shapesPool.ClearPool();
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
        public ShapesBuilder WithImage(ImageType imageType)
        {
            var imageData = _shapesBundle.InsideImages[imageType];
            _currentBuildingShape.SetInsideImage(imageData, imageType);
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
