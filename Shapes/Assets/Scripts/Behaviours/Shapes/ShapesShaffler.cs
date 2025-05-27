using System.Collections.Generic;

namespace Behaviours
{
    sealed class ShapesShaffler
    {
        private System.Random _random;

        public ShapesShaffler()
        {
            _random = new System.Random();
        }

        public List<Shape> ShaffleShapes(List<Shape> shapes)
        {
            for (int i = shapes.Count - 1; i >= 1; i--)
            {
                int j = _random.Next(i + 1);

                (shapes[j], shapes[i]) = (shapes[i], shapes[j]);
            }
            return shapes;
        }
    }
}
