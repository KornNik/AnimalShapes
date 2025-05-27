using Data;
using UnityEngine;

namespace Behaviours
{
    sealed class FactoryBuilder
    {
        private ShapesBuilder _builderCircle;
        private ShapesBuilder _builderTriangle;
        private ShapesBuilder _builderSquare;

        private ShapesBundle _shapesBundle;
        private Transform _spawnPoint;
        
        public FactoryBuilder(ShapesBundle shapesBundle, Transform spawnPoint)
        {
            _shapesBundle = shapesBundle;
            _spawnPoint = spawnPoint;
            _builderCircle = new ShapesBuilder(shapesBundle, spawnPoint, ShapeType.Circle);
            _builderTriangle = new ShapesBuilder(shapesBundle, spawnPoint, ShapeType.Triangle);
            _builderSquare = new ShapesBuilder(shapesBundle, spawnPoint, ShapeType.Square);
        }

        public Shape Create(ShapeType shapeType, Color color, ImageType imageType)
        {
            switch (shapeType)
            {
                case ShapeType.Circle:
                    return _builderCircle.CreateShape().WithColor(color).WithImage(imageType).
                        WithPosition(Vector3.zero).WithRotation(Quaternion.identity).Build();
                case ShapeType.Triangle:
                    return _builderTriangle.CreateShape().WithColor(color).WithImage(imageType).
                    WithPosition(Vector3.zero).WithRotation(Quaternion.identity).Build();
                case ShapeType.Square:
                    return _builderSquare.CreateShape().WithColor(color).WithImage(imageType).
                WithPosition(Vector3.zero).WithRotation(Quaternion.identity).Build();
                default:
                    return _builderSquare.CreateShape().WithColor(color).WithImage(imageType).
                        WithPosition(Vector3.zero).WithRotation(Quaternion.identity).Build();
            }
        }

        public void Clear()
        {
            _builderCircle.Clear();
            _builderTriangle.Clear();
            _builderSquare.Clear();
        }
        public void Destroy()
        {
            _builderCircle.DestroyPool();
            _builderTriangle.DestroyPool();
            _builderSquare.DestroyPool();
        }
    }
}
