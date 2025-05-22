using Data;
using UnityEngine;

namespace Behaviours
{
    sealed class FactoryBuilder
    {
        private ShapesBuilder _builderCircle;
        private ShapesBuilder _builderTriangle;
        private ShapesBuilder _builderSquare;

        public FactoryBuilder(ShapesBundle shapesBundle, Transform spawnPoint)
        {
            _builderCircle = new ShapesBuilder(shapesBundle, spawnPoint, ShapeType.Circle);
            _builderTriangle = new ShapesBuilder(shapesBundle, spawnPoint, ShapeType.Triangle);
            _builderSquare = new ShapesBuilder(shapesBundle, spawnPoint, ShapeType.Square);
        }
    }
}
