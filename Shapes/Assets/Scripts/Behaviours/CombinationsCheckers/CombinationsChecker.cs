using Behaviours;
using System.Collections.Generic;

namespace UI
{
    abstract class CombinationsChecker
    {
        protected ShapeSlot[] _shapeSlots;

        public abstract bool CheckForCombinations();
        protected virtual bool IsTwoShapesSimilar(ShapeInfo firstShape, ShapeInfo secondShape)
        {
            if (
                firstShape.Color == secondShape.Color &&
                firstShape.ImageType == secondShape.ImageType &&
                firstShape.ShapeType == secondShape.ShapeType
                )
            {
                return true;
            }
            return false;
        }
    }
}
